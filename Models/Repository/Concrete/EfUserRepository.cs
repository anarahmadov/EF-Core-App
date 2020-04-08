using CourseApp.Models.Repository.Abstraction;
using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repository.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private UserDbContext _dbContext;
        public EfUserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<User> Users => _dbContext.Users;
    }
}
