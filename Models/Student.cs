using System.Collections.Generic;

namespace CoursesWorkshop.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PreferredName { get; set; }
        public string AcademicStanding { get; set; }
        //public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseStudent> Enrollment { get; set; }
    }
}
