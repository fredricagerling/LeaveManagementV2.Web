using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Entities
{
    public class LeaveType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
