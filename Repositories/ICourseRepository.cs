using CoursesWorkshop.Models;
using System.Collections.Generic;

namespace CoursesWorkshop.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
    }
}
