using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Models;

namespace LeaveManagementV2.Web.Interfaces
{
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveRequest>
    {
        Task CreateLeaveRequest(LeaveRequestCreateViewModel model);
        Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestList();
    }
}
