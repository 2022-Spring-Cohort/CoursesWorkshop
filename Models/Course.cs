using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoursesWorkshop.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
        public string Image { get; set; }
        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public string Building { get; set; }
        public int RoomNumber { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<CourseStudent> Roster { get; set; }
        
    }
}
