using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext _context;
        private ICourseRepository _repo;
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            //return View(_repo.GetAll());
            return View(_context.Courses.ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(_repo.GetById(id));
        }
    }
}
