 using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace Student_Attendance_System.Models
    {
        public class AttendanceViewModel
        {
            [Key]
            public int AttendanceId { get; set; }
            public int StudentId { get; set; }

            [Display(Name = "Student Name")]
            public string StudentName { get; set; }

            public string Course { get; set; }

            public string Level { get; set; }

            [Display(Name = "Date of Attendance")]
            [DataType(DataType.Date)]
            public DateTime DateOfAttendance { get; set; }

            [Display(Name = "Mark Attendance")]
            public bool MarkAttendance { get; set; }
        }
    }
