using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models;
using WebApp2.Services;

namespace WebApp2.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService courseService;
        private readonly IConfiguration configuration;

        public CourseController(CourseService courseService, IConfiguration configuration)
        {
            this.courseService = courseService;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> course_list = courseService.GetCourses(configuration.GetConnectionString("SQLConnection"));
            return View(course_list);
        }
    }
}
