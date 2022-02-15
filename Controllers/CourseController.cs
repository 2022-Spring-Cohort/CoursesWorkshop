﻿using CoursesWorkshop.Models;
using CoursesWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Delete(int id)
        {
            _courseRepo.Delete(id);

            return RedirectToAction("Index");
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

        public IActionResult Edit(int id)
        {
            ViewBag.Instructors = _instructorRepo.GetAll();

            return View(_courseRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Course model)
        {
            ViewBag.Instructors = _instructorRepo.GetAll();
            ViewBag.Success = "";

            try
            {
                _courseRepo.Update(model);
                ViewBag.Success = "You have successfully changed this course.";
            }
            catch(Exception ex)
            {
                ViewBag.Error = "There was an issue saving your changes. Please contact administrator.";
            }
            

            return View(model);
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

            return RedirectToAction("Index", "Instructor");
        }
    }
}
