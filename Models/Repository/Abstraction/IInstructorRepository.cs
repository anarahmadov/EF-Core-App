using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Abstraction
{
    public interface IInstructorRepository
    {
        IQueryable<Instructor> Instructors { get; }

        Instructor GetById(int id);
        void UpdateInstructor(Instructor updatedInstructor, Instructor originalInstructor);
        void AddInstructor(Instructor newInstructor);
        void DeleteInstructor(int instructorId);
    }
}
