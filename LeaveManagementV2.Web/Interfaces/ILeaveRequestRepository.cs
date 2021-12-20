using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Models;

namespace LeaveManagementV2.Web.Interfaces
{
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveRequest>
    {
        Task CreateLeaveRequestAsync(LeaveRequestCreateViewModel model);
        Task<EmployeeLeaveRequestViewModel> GetLeaveRequestDetailsAsync();
        Task<LeaveRequestViewModel> GetLeaveRequestAsync(int? id);
        Task<List<LeaveRequest>> GetAllAsync(string employeeId);
        Task ChangeApprovalStatusAsync(int leaveRequestId, bool approved);
        Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestListAsync();
    }
}
