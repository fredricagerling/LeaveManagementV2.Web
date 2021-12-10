using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public LeaveTypeViewModel? LeaveType { get; set; }
    }
}
