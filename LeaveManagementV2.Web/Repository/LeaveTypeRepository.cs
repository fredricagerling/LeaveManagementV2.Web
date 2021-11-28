using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Data;
using LeaveManagementV2.Web.Interfaces;

namespace LeaveManagementV2.Web.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes!.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes!.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveTypes!.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _db.LeaveTypes!.Find(id)!;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes!.Update(entity);
            return Save();
        }
    }
}
