using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }

        public EmployeeViewModel? Employee { get; set; }
        public string? EmployeeId { get; set; }

        public EmployeeViewModel? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public IEnumerable<SelectListItem>? Employees { get; set; }
        public IEnumerable<SelectListItem>? LeaveTypes { get; set; }
    }
}
