﻿namespace LeaveManagementV2.Web.Models
{
    public class EmployeeLeaveRequestViewModel
    {
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
        public List<LeaveRequestViewModel> LeaveRequests { get; set; }

    }
}
