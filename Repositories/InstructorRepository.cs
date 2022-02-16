using CoursesWorkshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoursesWorkshop.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private ApplicationContext _context;

        public InstructorRepository()
        {
            _context = new ApplicationContext();
        }

        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public List<Instructor> GetAll()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.Instructors.Find(id);
        }
    }
}
