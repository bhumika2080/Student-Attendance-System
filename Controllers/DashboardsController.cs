using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

namespace Student_Attendance_System.Controllers
{
    [Authorize(Policy ="LoggedInPolicy")]
    public class DashboardsController : Controller
    {
        private readonly Student_Attendance_SystemContext _context;

        public DashboardsController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        // GET: Dashboards
        public async Task<IActionResult> Index()
        {
              return _context.Dashboard != null ? 
                          View(await _context.Dashboard.ToListAsync()) :
                          Problem("Entity set 'Student_Attendance_SystemContext.Dashboard'  is null.");
        }

        // GET: Dashboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dashboard == null)
            {
                return NotFound();
            }

            var dashboard = await _context.Dashboard
                .FirstOrDefaultAsync(m => m.id == id);
            if (dashboard == null)
            {
                return NotFound();
            }

            return View(dashboard);
        }

        // GET: Dashboards/Create
        public IActionResult Create()
        {
           /* var dataFromDatabase = _context.Dashboard.Select(item => item.SelectStudent).ToList();

            // Pass the data to the view
            ViewBag.LocalData = dataFromDatabase;*/
            

            return View();
        }

        /*// POST: Dashboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,SelectStudent,SelectCourses,Date,isPresent")] Dashboard dashboard)
        {
            if (ModelState.IsValid)
            {
                var Student_checking = _context.RegisterStudent.FirstOrDefault(a => a.StudentName == dashboard.SelectStudent && a.Course==dashboard.SelectCourses);
                *//*if (Student_checking != null)
                {*//*
                    _context.Add(dashboard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                *//*}*//*
            }
            ViewBag.ErrorMsg = "Please enter a valid Student Name or Course";
            return View(dashboard);
        }*/


        // POST: Dashboards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,SelectStudent,SelectCourses,Date,isPresent")] Dashboard dashboard)
        {
            if (ModelState.IsValid)
            {
                // Check if the selected student and course exist in the RegisterStudents database
                var studentExists = _context.RegisterStudent
                    .Any(a => a.StudentName.ToUpper() == dashboard.SelectStudent.ToUpper() &&
                    a.Course.ToUpper() == dashboard.SelectCourses.ToUpper());

                if (studentExists)
                {
                    // If the student exists, add the dashboard to the database
                    _context.Add(dashboard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                // If the student does not exist, show an error message
                ViewBag.ErrorMsg = "Please enter a valid Student Name and Course";
            }

            return View(dashboard);
        }




        // GET: Dashboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dashboard == null)
            {
                return NotFound();
            }

            var dashboard = await _context.Dashboard.FindAsync(id);
            if (dashboard == null)
            {
                return NotFound();
            }
            return View(dashboard);
        }

        // POST: Dashboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,SelectStudent,SelectCourses,Date,isPresent")] Dashboard dashboard)
        {
            if (id != dashboard.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashboardExists(dashboard.id))
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
            return View(dashboard);
        }

        // GET: Dashboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dashboard == null)
            {
                return NotFound();
            }

            var dashboard = await _context.Dashboard
                .FirstOrDefaultAsync(m => m.id == id);
            if (dashboard == null)
            {
                return NotFound();
            }

            return View(dashboard);
        }

        // POST: Dashboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dashboard == null)
            {
                return Problem("Entity set 'Student_Attendance_SystemContext.Dashboard'  is null.");
            }
            var dashboard = await _context.Dashboard.FindAsync(id);
            if (dashboard != null)
            {
                _context.Dashboard.Remove(dashboard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashboardExists(int id)
        {
          return (_context.Dashboard?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
