using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.Data;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementV2.Web.Controllers
{

    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveTypesController(
            ILeaveTypeRepository repo,
            IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository
            )
        {
            _repo = repo;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            List<LeaveTypeViewModel>? leaveTypes = _mapper.Map<List<LeaveTypeViewModel>>(await _repo.GetAllAsync());
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _repo.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeViewModel);
                await _repo.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _repo.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeViewModel);

                try
                {
                    await _repo.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _repo.Exists(leaveTypeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocationRepository.LeaveAllocation(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
