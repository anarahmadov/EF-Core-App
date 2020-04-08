using CourseApp.Models.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Concrete
{
    public class EfCourseRepository : ICourseRepository
    {
        private DataContext _dataContext;

        public EfCourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Course> Courses => _dataContext.Courses;

        public void AddCourse(Course newCourse)
        {
            _dataContext.Add(newCourse);
            _dataContext.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            _dataContext.Remove(new Course() { Id = courseId });
            _dataContext.SaveChanges();
        }

        public void UpdateCourse(Course updatedCourse, Course originalCourse)
        {
            if (originalCourse == null)
                _dataContext.Courses.Find(originalCourse);
            else
            {
                _dataContext.Courses.Attach(originalCourse);

            }

            originalCourse.Name = updatedCourse.Name;
            originalCourse.Description = updatedCourse.Description;
            originalCourse.Price = updatedCourse.Price;
            originalCourse.IsActive = originalCourse.IsActive;

            originalCourse.InstructorId = updatedCourse.InstructorId;
            originalCourse.Instructor.City = _dataContext.Instructors.First(x => x.Id == originalCourse.Instructor.Id).City;
            originalCourse.Instructor.Name = _dataContext.Instructors.First(x => x.Id == originalCourse.Instructor.Id).Name;

            //_dataContext.Entry(person).Property("Name").IsModified = true;
            //_dataContext.Entry(originalCourse).Property("Instructor").IsModified = true;
            //_dataContext.Entry(originalCourse).Reference(p => p.Instructor).Load();

            _dataContext.SaveChanges();
        }

        public Course GetById(int id)
        {
            return _dataContext.Courses.Include("Instructor").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Course> GetCoursesByIsActive(bool isActive)
        {
            return _dataContext.Courses.Where(x => x.IsActive == isActive);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dataContext.Courses;
        }

        public IEnumerable<Course> GetCoursesByFilter(string name, string isActive, decimal? price = null)
        {
            IQueryable<Course> query = _dataContext.Courses;

            if (name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            if (price != null)
            {
                query = query.Where(x => x.Price <= price);
            }

            if (isActive != null)
            {
                var check = isActive == "on" ? true : false;

                query = query.Where(x => x.IsActive == check);
            }

            return query.Include(x => x.Instructor);
        }
    }
}
