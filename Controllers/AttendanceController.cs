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
           // var students = _context.AttendanceViewModel.ToList();

            // Pass student data to the view
            return View(students);
        }

    
        [HttpPost]
        public IActionResult Index([FromBody]List<RegisterStudent> modelData)
        {
            return Json("Data Added successfully");
            try
            {
                // Ensure the ModelState is valid before proceeding
                if (ModelState.IsValid)
                {
                    // Save attendance to the database
                    _context.AttendanceViewModel.AddRange((IEnumerable<AttendanceViewModel>)modelData);
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
