using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Models
{
    public class AdminLeaveRequestViewModel
    {
        [Display(Name = "Total Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }
}