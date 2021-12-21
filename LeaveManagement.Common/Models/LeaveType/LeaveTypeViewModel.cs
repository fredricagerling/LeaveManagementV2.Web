using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name="Default number of days")]
        [Required]
        public int DefaultDays { get; set; }
    }
}
