using CoursesWorkshop.Models;
using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext _context;
        private ICourseRepository _courseRepo;
        private IInstructorRepository _instructorRepo;
        public CourseController(ICourseRepository courseRepo, IInstructorRepository instructorRepo)
        {
            _courseRepo = courseRepo;
            _instructorRepo = instructorRepo;

            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            //return View(_repo.GetAll());
            return View(_context.Courses.ToList());
        }

        public IActionResult Detail(int id)
        {
            return View(_courseRepo.GetById(id));
        }

        public IActionResult Add()
        {
            // TODO: Get Instructors
            ViewBag.Instructors = _instructorRepo.GetAll();

            return View(new Course() { });
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
