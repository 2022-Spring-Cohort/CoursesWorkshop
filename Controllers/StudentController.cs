using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesWorkshop;
using CoursesWorkshop.Models;

namespace CoursesWorkshop.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext _context;

        public StudentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PreferredName,AcademicStanding")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            Instructor selectedInstructor = _context.Instructors.Find(id);

            return View(selectedInstructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            Instructor instructorToUpdate = _context.Instructors.Find(instructor.Id);

            instructorToUpdate.FirstName = instructor.FirstName;
            instructorToUpdate.LastName = String.IsNullOrEmpty(instructor.LastName) ? instructorToUpdate.LastName : instructor.LastName;
            //instructorToUpdate.Department



            //_context.Instructors.Update(instructor);
            _context.SaveChanges();


            return View();
        }
       

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Register(int id)
        {
            Student currentStudent = _context.Students.Find(id);
            ViewBag.Courses = _context.Courses.Where(c => !currentStudent.Enrollment.Select(e => e.Course).Contains(c)).ToList();
            

            return View(currentStudent);
        }

        [HttpPost]
        public IActionResult Register(int id, int CourseId)
        {
            Student currentStudent = _context.Students.Find(id);
            Course courseToEnroll = _context.Courses.Find(CourseId);

            //currentStudent.Courses.Add(courseToEnroll);

            _context.CourseStudents.Add(new CourseStudent() { CourseId = CourseId, StudentId = id });

            //ViewBag.Courses = _context.Courses.Where(c => !currentStudent.Courses.Contains(c)).ToList();

            _context.SaveChanges();

            ViewBag.Courses = _context.Courses.Where(c => !currentStudent.Enrollment.Select(e => e.Course).Contains(c)).ToList();

            ViewBag.Success = "You have successfully registered this student for course: " + courseToEnroll.Name;
            
            return View(currentStudent);
            //return View(currentStudent);
        }

        public IActionResult RemoveEnrollment(int id)
        {
            CourseStudent enrollmentToRemove = _context.CourseStudents.Find(id);
            _context.CourseStudents.Remove(enrollmentToRemove);
            _context.SaveChanges();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        //public IActionResult RemoveEnrollment(int StudentId, int CourseId)
        //{
        //    Student studentToChange = _context.Students.Find(StudentId);
        //    Course courseToRemove = _context.Courses.Find(CourseId);

        //    //studentToChange.Courses.Remove(courseToRemove);
        //    //courseToRemove.Students.Remove(studentToChange);

        //    //_context.SaveChanges();

        //    return Redirect(Request.Headers["Referer"].ToString());
        //}

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
