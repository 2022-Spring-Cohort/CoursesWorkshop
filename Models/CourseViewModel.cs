using System.Collections.Generic;

namespace CoursesWorkshop.Models
{
    public class CourseViewModel
    {
        public virtual Course Course { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
    }
}
