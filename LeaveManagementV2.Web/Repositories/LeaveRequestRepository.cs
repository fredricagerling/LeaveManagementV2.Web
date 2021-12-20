using AutoMapper;
using LeaveManagementV2.Web.Data;
using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementV2.Web.Repositories
{
    public class LeaveRequestRepository : RepositoryBase<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestRepository(
            ApplicationDbContext context,
            IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> userManager) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _leaveAllocationRepo = leaveAllocationRepo;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task ChangeApprovalStatusAsync(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                var allocation = await _leaveAllocationRepo.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepo.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);
        }

        public async Task CreateLeaveRequestAsync(LeaveRequestCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }

        public async Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestListAsync()
        {
            var leaveRequests = await _context.LeaveRequests.Include(x => x.LeaveType).ToListAsync();

            var model =  new AdminLeaveRequestViewModel
            {
                TotalRequests = leaveRequests.Count(),
                ApprovedRequests = leaveRequests.Count(x => x.Approved == true),
                PendingRequests = leaveRequests.Count(x => x.Approved == null),
                RejectedRequests = leaveRequests.Count(x => x.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestViewModel>>(leaveRequests),
            };

            foreach (var request in model.LeaveRequests)
            {
                request.Employee = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(request.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == employeeId).Include(l => l.LeaveType).ToListAsync();
        }

        public async Task<LeaveRequestViewModel> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);
            if(leaveRequest == null)
            {
                return null;
            }

            var model = _mapper.Map<LeaveRequestViewModel>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeListViewModel>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return model;

        }

        public async Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetailsAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepo.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestViewModel>>(await GetAllAsync(user.Id));

            return new EmployeeLeaveRequestViewModel
            {
                LeaveAllocations = allocations,
                LeaveRequests = requests
            };
        }
    }
}
