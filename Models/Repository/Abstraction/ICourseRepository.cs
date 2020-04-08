using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Abstraction
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }

        Course GetById(int id);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesByIsActive(bool isActive);
        IEnumerable<Course> GetCoursesByFilter(string name, string isActive, decimal? price = null);
        void UpdateCourse(Course updatedCourse, Course originalCourse);
        void AddCourse(Course newCourse);
        void DeleteCourse(int courseId);
    }
}
