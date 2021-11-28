using LeaveManagementV2.Web.Entities;

namespace LeaveManagementV2.Web.Interfaces
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
    }
}
