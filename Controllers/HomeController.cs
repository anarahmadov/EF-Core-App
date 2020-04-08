using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dbContext;
        public HomeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(Request request)
        {
            _dbContext.Add(request);
            _dbContext.SaveChanges();

            return View("Thanks", request);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_dbContext.Requests);
        }
    }
}