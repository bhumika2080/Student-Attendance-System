using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace Student_Attendance_System.Models
{
    public class Dashboard
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        /*public List<StudentName> SelectStudent { get; set; }
        public List<Course> SelectCourses { get; set; }*/
        public string SelectStudent { get; set; }
        public string SelectCourses { get; set; }
        public bool isPresent { get; set; }
       /* public StudentName snp { get; set; }
        public Course course { get; set; }*/
    }
   /* public class StudentName 
    { 
        public int StudentNameID { get; set; }
        public string StName { get; set; }
    }
    public class Course
    {
        public int Courseid { get; set; }
        public string CourseName { get; set; }
    }   */
}
