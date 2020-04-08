using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Abstraction
{
    public interface IUnitOfWork
    {
        IInstructorRepository InstructorRepo { get; }
        ICourseRepository CourseRepo { get; }
    }
}
