using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

namespace Student_Attendance_System.Controllers
{
    [AllowAnonymous]
    public class LoginsController : Controller
    {
        private readonly Student_Attendance_SystemContext _context;

        public LoginsController(Student_Attendance_SystemContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
              return _context.Login != null ? 
                          View(await _context.Login.ToListAsync()) :
                          Problem("Entity set 'Student_Attendance_SystemContext.Login'  is null.");
        }

        // GET: Logins/Create
        public IActionResult LoginsView()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> LoginsView(*//*[Bind("Id,email,password")]*//* Login login)
         {
             *//*if (ModelState.IsValid)
             {
                 _context.Add(login);
                 await _context.SaveChangesAsync();
                 return RedirectToAction("Create","Dashboards");
             }*//*
             string username = "bhumika@gmail.com";
             string password = "Qaz!123";
             // _context.Login vaneko dbcontext vitra ko Login table ho 
             // ani FirstorDefault le first ma hune check garxa or default i.e, null return garxa
             var user = _context.Login.FirstOrDefault(x =>x.email == login.email);

                 if (user!=null && user.email==login.email && user.password == login.password)
                 {
                 // Database ma data save garne ho vane matrai yo 2ta line use hunxa
                     *//*_context.Add(login);*/
        /*await _context.SaveChangesAsync();*//*
        return RedirectToAction("Create","RegisterStudents");
    }

return View(login);

}*/


        // POST: Logins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginsView(Login login/*, string returnUrl=null*/)
        {
            // Check if the provided credentials match any record in the Login table
            var user = _context.Login.FirstOrDefault(x => x.email == login.email && x.password == login.password);

            // If a matching user is found, redirect to the "Create" action of the "RegisterStudents" controller
            if (user != null)
            {
                return RedirectToAction("Create", "RegisterStudents");
                // Use returnUrl if provided, otherwise redirect to a default location
                // return Redirect(returnUrl ?? Url.Action("Create", "RegisterStudents"));

            }

            // If no matching user is found, return the login view
            ViewBag.ErrorMessage = "Invalid email or password. Please try again.";
            return View(login);
        }



        private bool LoginExists(int id)
        {
          return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
