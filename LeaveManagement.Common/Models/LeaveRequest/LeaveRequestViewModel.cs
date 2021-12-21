using LeaveManagement.Common.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveRequestViewModel : LeaveRequestCreateViewModel
    {
        public int Id { get; set; }

        [ForeignKey("LeaveTypeId")]
        [Display(Name = "Leave Type")]
        public LeaveTypeViewModel LeaveType { get; set; }

        [Display(Name = "Date Requested")]
        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListViewModel Employee { get; set; }
    }
}
