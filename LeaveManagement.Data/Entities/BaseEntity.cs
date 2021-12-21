using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
