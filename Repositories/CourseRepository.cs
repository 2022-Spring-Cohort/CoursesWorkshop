using CoursesWorkshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoursesWorkshop.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ApplicationContext _context;

        public CourseRepository()
        {
            _context = new ApplicationContext();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }
    }
}
