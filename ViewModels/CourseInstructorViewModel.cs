using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.ViewModels
{
    public class CourseInstructorViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
