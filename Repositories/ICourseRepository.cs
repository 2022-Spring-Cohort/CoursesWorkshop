using CoursesWorkshop.Models;
using System.Collections.Generic;

namespace CoursesWorkshop.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);

        void Update(Course course);
        void Create(Course course);
        void Delete(int id);
    }
}
