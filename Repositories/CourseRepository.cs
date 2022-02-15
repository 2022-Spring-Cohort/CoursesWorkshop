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

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Course courseToDelete = _context.Courses.Find(id);
            _context.Courses.Remove(courseToDelete);
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}
