using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace Student_Attendance_System.Models
{
    public class Dashboard
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string SelectStudent { get; set; }
        public string SelectCourses { get; set; }

        public bool isPresent { get; set; }
    }
}
