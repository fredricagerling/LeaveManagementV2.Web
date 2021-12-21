using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Data
{
    public class LeaveType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
