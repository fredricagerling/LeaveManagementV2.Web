﻿using AutoMapper;
using LeaveManagementV2.Web.Constants;
using LeaveManagementV2.Web.Data;
using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementV2.Web.Repositories
{
    public class LeaveAllocationRepository : RepositoryBase<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationRepository(ApplicationDbContext context, UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<EmployeeAllocationViewModel> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationViewModel>(employee);
            employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationViewModel>>(allocations);

            return employeeAllocationModel;

        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();

            foreach (var employee in employees)
            {
                if(await AllocationExists(employee.Id, leaveTypeId, period))
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
            }

            await AddRangeAsync(allocations);
        }
    }
}
