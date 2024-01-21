/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

namespace Student_Attendance_System.Controllers
{
    public class AttendanceViewModelsController : Controller
    {
        private readonly Student_Attendance_SystemContext _context;

        public AttendanceViewModelsController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        // GET: AttendanceViewModels
        public async Task<IActionResult> Index()
        {
              return _context.AttendanceViewModel != null ? 
                          View(await _context.AttendanceViewModel.ToListAsync()) :
                          Problem("Entity set 'Student_Attendance_SystemContext.AttendanceViewModel'  is null.");
        }

        // GET: AttendanceViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AttendanceViewModel == null)
            {
                return NotFound();
            }

            var attendanceViewModel = await _context.AttendanceViewModel
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendanceViewModel == null)
            {
                return NotFound();
            }

            return View(attendanceViewModel);
        }

        // GET: AttendanceViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendanceViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,StudentId,StudentName,Course,Level,DateOfAttendance,MarkAttendance")] AttendanceViewModel attendanceViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendanceViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendanceViewModel);
        }

        // GET: AttendanceViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AttendanceViewModel == null)
            {
                return NotFound();
            }

            var attendanceViewModel = await _context.AttendanceViewModel.FindAsync(id);
            if (attendanceViewModel == null)
            {
                return NotFound();
            }
            return View(attendanceViewModel);
        }

        // POST: AttendanceViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,StudentId,StudentName,Course,Level,DateOfAttendance,MarkAttendance")] AttendanceViewModel attendanceViewModel)
        {
            if (id != attendanceViewModel.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceViewModelExists(attendanceViewModel.AttendanceId))
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
            return View(attendanceViewModel);
        }

        // GET: AttendanceViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AttendanceViewModel == null)
            {
                return NotFound();
            }

            var attendanceViewModel = await _context.AttendanceViewModel
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendanceViewModel == null)
            {
                return NotFound();
            }

            return View(attendanceViewModel);
        }

        // POST: AttendanceViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AttendanceViewModel == null)
            {
                return Problem("Entity set 'Student_Attendance_SystemContext.AttendanceViewModel'  is null.");
            }
            var attendanceViewModel = await _context.AttendanceViewModel.FindAsync(id);
            if (attendanceViewModel != null)
            {
                _context.AttendanceViewModel.Remove(attendanceViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult SaveAttendance(List<RegisterStudent> attendanceData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Assuming you have a DbContextOptions configured in your application startup
                    DbContextOptions<Student_Attendance_SystemContext> dbContextOptions =
                        new DbContextOptionsBuilder<Student_Attendance_SystemContext>()
                        .UseSqlServer("YourConnectionString") // Replace with your actual connection string
                        .Options;

                    // Create an instance of Student_Attendance_SystemContext with the provided options
                    using (var dbContext = new Student_Attendance_SystemContext(dbContextOptions))
                    {
                        // Save the attendance data to the same table
                        dbContext.RegisterStudent.AddRange(attendanceData);
                        dbContext.SaveChanges();
                    }

                    // Redirect to another action or view after saving
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log errors, etc.
                    ModelState.AddModelError("", "An error occurred while processing the attendance data.");
                }
            }

            // If ModelState is not valid, return to the same view with validation errors
            return View("Index", attendanceData);
        }


        private bool AttendanceViewModelExists(int id)
        {
          return (_context.AttendanceViewModel?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}
*/