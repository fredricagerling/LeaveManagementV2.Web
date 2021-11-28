using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
