using LeaveManagement.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaxId { get; set; }

        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime DateOfBirth { get; set; }

        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime DateJoined { get; set; }
    }
}
