using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

namespace Student_Attendance_System.Controllers
{
    /*public class AttendanceController : Controller
    {
        private readonly Student_Attendance_SystemContext _context;

        public AttendanceController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        // GET: Attendance
        public async Task<IActionResult> Index()
        {
              return _context.AttendanceViewModel != null ? 
                          View(await _context.AttendanceViewModel.ToListAsync()) :
                          Problem("Entity set 'Student_Attendance_SystemContext.AttendanceViewModel'  is null.");
        }

        // GET: Attendance/Details/5
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

        // GET: Attendance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendance/Create
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

        // GET: Attendance/Edit/5
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

        // POST: Attendance/Edit/5
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

        // GET: Attendance/Delete/5
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

        // POST: Attendance/Delete/5
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

        [HttpGet]
        public IActionResult Dashboard()
        {

            List<RegisterStudent> students = _context.RegisterStudent.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult SaveAttendance(List<AttendanceViewModel> attendanceRecords)
        {
            if (ModelState.IsValid)
            {
                foreach (var record in attendanceRecords)
                {
                    var student = _context.RegisterStudent.Find(record.AttendanceId);

                    var attendanceRecord = new AttendanceViewModel
                    {
                        StudentName = student.StudentName,
                        Course = student.Course,
                        Level = student.Level,
                        DateOfAttendance = record.DateOfAttendance,
                        MarkAttendance = record.MarkAttendance
                    };

                    _context.AttendanceViewModel.Add(attendanceRecord);
                }

                _context.SaveChanges();
                return RedirectToAction("Create","RegisterStudents");
            }

            // If the model state is not valid, handle accordingly
            // For simplicity, redirecting to the dashboard with an error message
            TempData["ErrorMessage"] = "Invalid data submitted. Please check your entries.";
            return RedirectToAction("Dashboard");
        }

        private bool AttendanceViewModelExists(int id)
        {
          return (_context.AttendanceViewModel?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }*/



    public class AttendanceController : Controller
    {
        // Assuming you have a database context named ApplicationDbContext
        private readonly Student_Attendance_SystemContext _context;

        public AttendanceController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch student data
            var students = _context.RegisterStudent.ToList();

            // Pass student data to the view
            return View(students);
        }

        /* [HttpPost]
         public IActionResult SaveAttendance(List<AttendanceViewModel> attendanceList)
         {
             // Save attendance to the database
             _context.AttendanceViewModel.AddRange(attendanceList);
             _context.SaveChanges();

             // Redirect to the attendance view or another appropriate page
             return RedirectToAction("Index");
         }*/

        [HttpPost]
        public IActionResult SaveAttendance(List<AttendanceViewModel> attendanceList)
        {
            try
            {
                // Ensure the ModelState is valid before proceeding
                if (ModelState.IsValid)
                {
                    // Save attendance to the database
                    _context.AttendanceViewModel.AddRange(attendanceList);
                    _context.SaveChanges();

                    // Redirect to the attendance view or another appropriate page
                    return RedirectToAction("Index");
                }

                // If ModelState is not valid, return to the same view with validation errors
                var students = _context.RegisterStudent.ToList();
                return View("Index", students);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return View("Error");
            }
        }

    }




}
