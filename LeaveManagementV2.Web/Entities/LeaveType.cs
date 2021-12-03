using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Entities
{
    public class LeaveType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
