using lab4.Models;
using lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
         if (!ModelState.IsValid)
            {
                ViewModel.Categories = _dbContext.Categories.ToList();
                return View("Create",viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                Datatime = viewModel.GetDataTime(),
                CatagoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SavaChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
