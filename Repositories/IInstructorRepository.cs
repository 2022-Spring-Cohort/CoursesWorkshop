using CoursesWorkshop.Models;
using System.Collections.Generic;

namespace CoursesWorkshop.Repositories
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor instructor);

        void Update(Instructor instructor);
        void Delete(int id);
    }
}
