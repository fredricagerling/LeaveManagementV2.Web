namespace LeaveManagementV2.Web.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public EmployeeViewModel? Employee { get; set; }
        public string? EmployeeId { get; set; }
        public EmployeeViewModel? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
