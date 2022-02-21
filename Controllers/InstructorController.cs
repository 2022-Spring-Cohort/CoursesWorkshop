using CoursesWorkshop.Models;
using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationContext _context;
        private IGenericRepository<Instructor> _repo;
        public InstructorController(IGenericRepository<Instructor> repo)
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

            _repo.Create(instructor);

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

        public IActionResult Delete(int id)
        {
            return View(_context.Instructors.Find(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id, Instructor instructor)
        {
            Instructor instructorToDelete = _context.Instructors.Where(i => i.Id == instructor.Id).FirstOrDefault();
            if (instructorToDelete != null)
            {
                _context.Instructors.Remove(instructorToDelete);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }


            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Instructor model = _repo.GetById(id);

            return View(model);
        }

        public IActionResult Edit(int id)
        {

            return View(_context.Instructors.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, Instructor model) 
        {
            //_repo.Update(model);

            _context.Instructors.Update(model);
            _context.SaveChanges();

            //return View(model);
            return RedirectToAction("Detail", new { id = model.Id });
        }
    }
}
