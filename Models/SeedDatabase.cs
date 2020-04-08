using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class SeedDatabase
    {
        public static void Seed(DbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Count() == 0)

            {
                if (dbContext is DataContext)
                {
                    // DataContext

                    var context = dbContext as DataContext;

                    if (context.Instructors.Count() == 0)
                    {
                        context.Instructors.AddRange(Instructors);
                    }

                    if (context.Courses.Count() == 0)
                    {
                        context.Courses.AddRange(Courses);
                    }
                }

                if (dbContext is UserDbContext)
                {
                    // UserDbContext

                    var context = dbContext as UserDbContext;

                    if (context.Users.Count() == 0)
                    {
                        context.Users.AddRange(users);
                    }
                }

                dbContext.SaveChanges();
            }
        }

        private static Course[] Courses
        {
            get
            {
                return new Course[]
                {
                    new Course(){ Name = "HTML", Description="All About HTML", Price=10, IsActive=true, Instructor=Instructors[0]},
                    new Course(){ Name = "CSS", Description="All About CSS", Price=20, IsActive=false, Instructor=Instructors[1]},
                    new Course(){ Name = "Javascript", Description="All About Javascript", Price=10, IsActive=true, Instructor=Instructors[2]},
                    new Course(){ Name = "NodeJS", Description="All About NodeJS", Price=10, IsActive=true, Instructor=Instructors[3]},
                    new Course(){ Name = "Angular", Description="All About Angular", Price=20, IsActive=false, Instructor=Instructors[0]},
                    new Course(){ Name = "React", Description="All About React", Price=10, IsActive=true},
                    new Course(){ Name = "MVC", Description="All About MVC", Price=20, IsActive=false}
                };
            }
        }

        private static Instructor[] Instructors = new Instructor[]
        {
             new Instructor(){ Name="Ahmet", City="Istanbul"},
             new Instructor(){ Name="Mehmet", City="Istanbul"},
             new Instructor(){ Name="Ali", City="Istanbul"},
             new Instructor(){ Name="Anar", City="Istanbul"}
        };


        //private static Instructor[] Instructors
        //{
        //    get
        //    {
        //        return new Instructor[]
        //        {
        //             new Instructor(){ Name="Ahmet", City="Istanbul"},
        //             new Instructor(){ Name="Mehmet", City="Istanbul"},
        //             new Instructor(){ Name="Ali", City="Istanbul"},
        //             new Instructor(){ Name="Anar", City="Istanbul"}
        //        };

        //    }
        //}


        private static User[] users = new User[]
        {
            new User(){ Username="anaraxmed5514", Password="anar1234", City="Paris" },
            new User(){ Username="anarahmad5514", Password="anar1234", City="Baku" },
            new User(){ Username="khudiyev", Password="anar1234", City="New York" },
            new User(){ Username="eli514", Password="anar1234", City="Berlin" }
        };

    }
}
