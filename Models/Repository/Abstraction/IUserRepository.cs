using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Abstraction
{
    public interface IUserRepository
    {
        public IQueryable<User> Users { get; }
    }
}
