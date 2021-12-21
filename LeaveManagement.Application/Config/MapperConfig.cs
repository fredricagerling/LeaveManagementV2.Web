using AutoMapper;
using LeaveManagement.Data;
using LeaveManagementV2.Web.Models;

namespace LeaveManagementV2.Web.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestCreateViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap();
        }
    }
}
