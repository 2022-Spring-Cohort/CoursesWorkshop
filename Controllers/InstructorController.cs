using CoursesWorkshop.Models;
using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationContext _context;
        private IInstructorRepository _repo;
        public InstructorController(IInstructorRepository repo)
        {
            _context = new ApplicationContext();
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_context.Instructors.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            if (string.IsNullOrEmpty(instructor.FirstName))
            {
                ViewBag.Error = "That instructor could not be saved.";
                return View(instructor);
            }

            _repo.Add(instructor);

            return RedirectToAction("Index");
        }

        public IActionResult AddCourse(int id)
        {
            ViewBag.Courses = _context.Courses.ToList();

            Instructor result = _context.Instructors.Find(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult AddCourse(Instructor model, int CourseId)
        {
            //Instructor editInstructor = _context.Instructors.Find(model.Id);

            Course course = _context.Courses.Find(CourseId);
            course.InstructorId = model.Id;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
