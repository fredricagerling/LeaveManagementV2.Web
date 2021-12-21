using LeaveManagement.Common.Constants;
using LeaveManagement.Data;
using LeaveManagementV2.Web.Interfaces;
using LeaveManagementV2.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementV2.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILogger _logger;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepo, ILogger logger)
        {
            _context = context;
            _leaveRequestRepo = leaveRequestRepo;
            _logger = logger;
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestRepo.GetAdminLeaveRequestListAsync();
            return View(model);
        }

        public async Task<IActionResult> MyLeave()
        {
            var model = await _leaveRequestRepo.GetLeaveRequestDetailsAsync();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _leaveRequestRepo.GetLeaveRequestAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {

            try
            {

                await _leaveRequestRepo.ChangeApprovalStatusAsync(id, approved);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestCreateViewModel
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name")
            };

            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _leaveRequestRepo.CreateLeaveRequestAsync(model);
                    return RedirectToAction(nameof(MyLeave));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Leave Request");

                ModelState.AddModelError(string.Empty, "An error has occurred");
            }

            model.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _leaveRequestRepo.CancelLeaveRequest(id);

            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
