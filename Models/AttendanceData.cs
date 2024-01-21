/*using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Attendance_System.Models
{
    public class AttendanceData
    {
        public int AttendanceDataId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresentToday { get; set; }

        // Foreign keys
        public int StudentName { get; set; }
        public int CourseName { get; set; }
        public int LevelName { get; set; }

        // Navigation properties
        [ForeignKey("StudentName")]
        public RegisterStudent RegisterStudent { get; set; }

        [ForeignKey("CourseName")]
        public Course Course { get; set; }

        [ForeignKey("LevelName")]
        public Level Level { get; set; }

    }
}
*/