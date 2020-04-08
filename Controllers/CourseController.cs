using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using CourseApp.Models.Repository.Abstraction;
using CourseApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ICourseRepository _courseRepository;
        public CourseController(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string name, string isActive, decimal? price = null)
        {
            return View(_unitOfWork.CourseRepo.GetCoursesByFilter(name, isActive, price));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit", new Course());
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (course != null)
            {
                _unitOfWork.CourseRepo.AddCourse(course);

                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ActionMode = "Edit";

            //CourseInstructorViewModel vm = new CourseInstructorViewModel()
            //{
            //    Course = _unitOfWork.CourseRepo.GetById(id),
            //    Instructors = _unitOfWork.InstructorRepo.Instructors
            //};


            ViewBag.Instructors = new SelectList(_unitOfWork.InstructorRepo.Instructors, "Id", "Name");

            var course = _unitOfWork.CourseRepo.GetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course model, Course original)
        {
            if (model != null)
            {

                TryUpdateModelAsync<Course>(model, "",
                    c => c.Name, c => c.Price, c => c.IsActive, c => c.Instructor.Id);

                _unitOfWork.CourseRepo.UpdateCourse(model, original);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int courseId)
        {
            _unitOfWork.CourseRepo.DeleteCourse(courseId);

            return RedirectToAction("Index");
        }
    }
}