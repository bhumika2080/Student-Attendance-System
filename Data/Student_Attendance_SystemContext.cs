using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Attendance_System.Models;

    public class Student_Attendance_SystemContext : DbContext
    {
        public Student_Attendance_SystemContext (DbContextOptions<Student_Attendance_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Attendance_System.Models.RegisterStudent> RegisterStudent { get; set; } = default!;

        public DbSet<Student_Attendance_System.Models.Login>? Login { get; set; }

        public DbSet<Student_Attendance_System.Models.Dashboard>? Dashboard { get; set; }

        public DbSet<Student_Attendance_System.Models.Course>? Course { get; set; }

        public DbSet<Student_Attendance_System.Models.Level>? Level { get; set; }

       /* public DbSet<Student_Attendance_System.Models.AttendanceData>? AttendanceData { get; set; }*/

        public DbSet<Student_Attendance_System.Models.AttendanceViewModel>? AttendanceViewModel { get; set; }

}
