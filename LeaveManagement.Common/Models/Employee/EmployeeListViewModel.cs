using LeaveManagement.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class EmployeeListViewModel
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime DateJoined { get; set; }
    }
}
