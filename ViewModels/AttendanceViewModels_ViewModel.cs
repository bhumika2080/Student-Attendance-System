using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Student_Attendance_System.ViewModels
{
    public class AttendanceViewModels_ViewModel
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Course { get; set; }

        public string Level { get; set; }

        public DateTime DateOfAttendance { get; set; }
        public bool MarkAttendance { get; set; }
    }
}
