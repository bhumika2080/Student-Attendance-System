﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

namespace Student_Attendance_System.Controllers
{
    [Authorize(Policy = "LoggedInPolicy")]
    public class RegisterStudentsController : Controller
    {
        private readonly Student_Attendance_SystemContext _context;

        public RegisterStudentsController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        // GET: RegisterStudents
        public async Task<IActionResult> Index()
        {
              return _context.RegisterStudent != null ? 
                          View(await _context.RegisterStudent.ToListAsync()) :
                          Problem("Entity set 'Student_Attendance_SystemContext.RegisterStudent'  is null.");
        }

        // GET: RegisterStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegisterStudent == null)
            {
                return NotFound();
            }

            var registerStudent = await _context.RegisterStudent
                .FirstOrDefaultAsync(m => m.id == id);
            if (registerStudent == null)
            {
                return NotFound();
            }

            return View(registerStudent);
        }

        // GET: RegisterStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,StudentName,Course,Level,DateEnrolled")] RegisterStudent registerStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerStudent);
        }

        // GET: RegisterStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegisterStudent == null)
            {
                return NotFound();
            }

            var registerStudent = await _context.RegisterStudent.FindAsync(id);
            if (registerStudent == null)
            {
                return NotFound();
            }
            return View(registerStudent);
        }

        // POST: RegisterStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,StudentName,Course,Level,DateEnrolled")] RegisterStudent registerStudent)
        {
            if (id != registerStudent.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterStudentExists(registerStudent.id))
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
            return View(registerStudent);
        }

        // GET: RegisterStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegisterStudent == null)
            {
                return NotFound();
            }

            var registerStudent = await _context.RegisterStudent
                .FirstOrDefaultAsync(m => m.id == id);
            if (registerStudent == null)
            {
                return NotFound();
            }

            return View(registerStudent);
        }

        // POST: RegisterStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegisterStudent == null)
            {
                return Problem("Entity set 'Student_Attendance_SystemContext.RegisterStudent'  is null.");
            }
            var registerStudent = await _context.RegisterStudent.FindAsync(id);
            if (registerStudent != null)
            {
                _context.RegisterStudent.Remove(registerStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterStudentExists(int id)
        {
          return (_context.RegisterStudent?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
