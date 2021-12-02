using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Display(Name="Default number of days")]
        public int DefaultDays { get; set; }
    }
}
