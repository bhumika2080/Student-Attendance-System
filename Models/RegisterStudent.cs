using System.ComponentModel.DataAnnotations;

namespace Student_Attendance_System.Models
{
    public class RegisterStudent
    {
        public int id { get; set; }
        [Display(Name ="Student Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string StudentName { get; set; }
        public string Course { get; set; }
        public string Level { get; set; }
        [Display(Name ="Date of Enrollment")]
        public DateTime DateEnrolled { get; set; }
    }
}
