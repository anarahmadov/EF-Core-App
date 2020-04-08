using CourseApp.Models.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Concrete
{
    public class EfInstructorRepository : IInstructorRepository
    {
        private DataContext _dataContext;
        public EfInstructorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Instructor> Instructors => _dataContext.Instructors;

        public void AddInstructor(Instructor newInstructor)
        {
            _dataContext.Instructors.Add(newInstructor);
            _dataContext.SaveChanges();
        }

        public void DeleteInstructor(int instructorId)
        {
            _dataContext.Instructors.Remove(new Instructor() { Id = instructorId });
            _dataContext.SaveChanges();
        }

        public Instructor GetById(int id)
        {
            return Instructors.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateInstructor(Instructor updatedInstructor, Instructor originalInstructor)
        {
            if (originalInstructor == null)
            {
                originalInstructor = _dataContext.Instructors.Find(originalInstructor);
            }
            else
            {
                _dataContext.Instructors.Attach(originalInstructor);
            }

            originalInstructor.Name = updatedInstructor.Name;
            originalInstructor.City = updatedInstructor.City;

            _dataContext.SaveChanges();
        }
    }
}
