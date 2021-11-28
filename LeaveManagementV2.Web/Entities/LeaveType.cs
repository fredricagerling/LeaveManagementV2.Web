using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Entities
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
