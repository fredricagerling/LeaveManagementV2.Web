using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveAllocationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1, 60, ErrorMessage = "You entered an invalid number")]
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }

        public LeaveTypeViewModel? LeaveType { get; set; }
    }
}
