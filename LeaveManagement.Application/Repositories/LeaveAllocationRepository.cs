using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Data;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementV2.Web.Repositories
{
    public class LeaveAllocationRepository : RepositoryBase<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, AutoMapper.IConfigurationProvider configurationProvider, IEmailSender emailSender) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId)
        {
            var employee = await _userManager.FindByIdAsync(employeeId);
            var model = _mapper.Map<EmployeeAllocationViewModel>(employee);

            model.LeaveAllocations = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .Where(x => x.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationViewModel>(_configurationProvider)
                .ToListAsync();

            return model;
        }

        public async Task<LeaveAllocationEditViewModel> GetEmployeeAllocation(int id)
        {
            var model = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .ProjectTo<LeaveAllocationEditViewModel>(_configurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(model.EmployeeId);

            model.Employee = _mapper.Map<EmployeeListViewModel>(employee);

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithNewAllocation = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                {
                    continue;
                }

                var allocation = new LeaveAllocation()
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType!.DefaultDays
                };

                allocations.Add(allocation);
                employeesWithNewAllocation.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach (var employee in employeesWithNewAllocation)
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your leave request from {leaveType.Name} has been posted for the period of {period}. You have been given {leaveType.DefaultDays} days.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditViewModel model)
        {
            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId);
        }
    }
}
