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

        public async Task CreateLeaveRequest(LeaveRequestCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == employeeId).Include(l => l.LeaveType).ToListAsync();
        }

        public async Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepo.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestViewModel>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestViewModel
            {
                LeaveAllocations = allocations,
                LeaveRequests = requests
            };

            return model;
        }
    }
}
