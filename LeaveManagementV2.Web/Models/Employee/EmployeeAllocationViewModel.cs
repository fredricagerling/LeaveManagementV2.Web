namespace LeaveManagementV2.Web.Models
{
    public class EmployeeAllocationViewModel : EmployeeListViewModel
    {
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
    }
}
