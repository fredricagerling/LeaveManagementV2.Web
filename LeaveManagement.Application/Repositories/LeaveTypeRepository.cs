using LeaveManagement.Data;
using LeaveManagementV2.Web.Interfaces;

namespace LeaveManagementV2.Web.Repositories
{
    public class LeaveTypeRepository : RepositoryBase<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
