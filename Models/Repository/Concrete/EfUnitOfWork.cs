using CourseApp.Models.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        public EfUnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IInstructorRepository InstructorRepo => new EfInstructorRepository(_dataContext);

        public ICourseRepository CourseRepo => new EfCourseRepository(_dataContext);
    }
}
