using CoursesWorkshop.Models;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public Instructor GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
