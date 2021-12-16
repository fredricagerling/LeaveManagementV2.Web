using AutoMapper;
using LeaveManagementV2.Web.Constants;
using LeaveManagementV2.Web.Entities;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LeaveManagementV2.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _repo;

        public EmployeesController(UserManager<Employee> userManager, IMapper mapper, ILeaveAllocationRepository repo)
        {
            _userManager = userManager;
            _mapper = mapper;
            _repo = repo;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var model = _mapper.Map<List<EmployeeListViewModel>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await _repo.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/Edit/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var model = await _repo.GetEmployeeAllocation(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool didUpdate = await _repo.UpdateEmployeeAllocation(model);

                    if (!didUpdate)
                    {
                        throw new Exception();
                    }

                    return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occurred");
            }

            model.Employee = _mapper.Map<EmployeeListViewModel>(_userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeViewModel>(await _repo.GetAsync(model.LeaveTypeId));

            return View(model);
        }

        // GET: EmployeesController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
