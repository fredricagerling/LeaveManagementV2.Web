using AutoMapper;
using LeaveManagement.Data;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementV2.Web.Repositories
{
    public class LeaveRequestRepository : RepositoryBase<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestRepository(
            ApplicationDbContext context,
            IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepo,
            IHttpContextAccessor httpContextAccessor,
            IEmailSender emailSender,
            UserManager<Employee> userManager) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _leaveAllocationRepo = leaveAllocationRepo;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await UpdateAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request Status Cancelled", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been cancelled.");
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

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved" : "Declined";

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request Status {approvalStatus}", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus.ToLower()}.");
        }

        public async Task CreateLeaveRequestAsync(LeaveRequestCreateViewModel model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfully", $"Your leave request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval");
        }

        public async Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestListAsync()
        {
            var leaveRequests = await _context.LeaveRequests.Include(x => x.LeaveType).ToListAsync();

            var model = new AdminLeaveRequestViewModel
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
            if (leaveRequest == null)
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
