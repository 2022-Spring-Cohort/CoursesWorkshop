using System.Collections.Generic;

namespace CoursesWorkshop.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string FullName { get { return FirstName + " " + LastName;} }
        public string Email { get; set; }
        public string Department { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
