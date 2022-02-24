using CoursesWorkshop.Models;
using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoursesWorkshop.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext _context;
        //private IGenericRepository<Course> _courseRepo;
        //private IGenericRepository<Instructor> _instructorRepo;
        private ApplicationUser _user;
        private readonly string ApplicationRoot = "/Users/Student/source/repos/CoursesWorkshop/";
        public CourseController(ApplicationContext context)
        {
            //_courseRepo = new GenericRepository<Course>();
            //_instructorRepo = new GenericRepository<Instructor>();

            _context = context;

            //if (User.Identity.IsAuthenticated)
            //{
            //    _user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            //}

        }

        public IActionResult Index()
        {
            

            //if (User.Identity.IsAuthenticated)
            //{
            //    return View(_context.Courses.Where(c => c.DepartmentCode == _user.DepartmentCode).ToList());
            //}

            return View(_context.Courses.ToList());
        }

        public IActionResult Create()
        {
            return View(new CourseViewModel() { Course = new Course(), Instructors = _context.Instructors.ToList() });
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel model, IFormFile CourseImage)
        {
            string uploads = Path.Combine(ApplicationRoot, "wwwroot/uploads/");

            if(CourseImage.Length > 0)
            {
                string filePath = Path.Combine(uploads, CourseImage.FileName);
                using(Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    CourseImage.CopyTo(fileStream);
                }
            }

            try
            {
                model.Course.Image = CourseImage.FileName;
                _context.Courses.Add(model.Course);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {

            }

            return View(model);
            
        }

        public IActionResult Delete(int id)
        {
            

            return View(_context.Courses.Find(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Course model)
        {
            Course courseToDelete = _context.Courses.Find(id);
            _context.Courses.Remove(courseToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            return View(_context.Courses.Find(id));
        }

       

        public IActionResult Edit(int id)
        {
            //ViewBag.InstructorId = _context.Instructors.ToList();

            //ViewData["InstructorId"] = _context.Instructors.ToList();


            Course model = _context.Courses.Find(id);
            return View(new CourseViewModel() { Course = model, Instructors = _context.Instructors.ToList() });
        }

        [HttpPost]
        public IActionResult Edit(int id, CourseViewModel model, IFormFile CourseImage)
        {
            ViewBag.InstructorId = _context.Instructors.ToList();

            string uploads = Path.Combine(ApplicationRoot, "wwwroot/uploads/");

            if (CourseImage?.Length > 0)
            {
                model.Course.Image = CourseImage.FileName;
                string filePath = Path.Combine(uploads, CourseImage.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    CourseImage.CopyTo(fileStream);
                }
            }

            if (String.IsNullOrEmpty(model.Course.Name))
            {
                ViewBag.Error = "You have a name";

                return View(model);
            }
            else
            {
                
                _context.Courses.Update(model.Course);
                _context.SaveChanges();

                return RedirectToAction("Detail", "Course", new { id = id });
            }

            
        }

        public IActionResult RemoveImage(int id)
        {
            Course courseToModify = _context.Courses.Find(id);

            // TODO: Remove File From Uploads Folder
            string uploads = Path.Combine(ApplicationRoot, "wwwroot/uploads/");
            FileInfo file = new FileInfo(uploads + courseToModify.Image);

            if (file.Exists)
            {
                file.Delete();
            }

            courseToModify.Image = String.Empty;
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = id });
        }
       

        public IActionResult AddByInstructorId(int instructorId)
        {
            return View(new Course() { InstructorId = instructorId, Instructor = _context.Instructors.Find(instructorId) });
        }

        [HttpPost]
        public IActionResult AddByInstructorId(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
            //_courseRepo.Create(model);

            return RedirectToAction("Detail", "Instructor", new { id = model.InstructorId });
        }
    }
}
