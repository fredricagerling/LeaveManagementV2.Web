using LeaveManagement.Data;
using LeaveManagementV2.Web.Models;

namespace LeaveManagementV2.Web.Interfaces
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
        Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId);
        Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model);
    }
}
