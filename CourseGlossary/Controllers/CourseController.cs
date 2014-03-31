using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseGlossary.DataLayer;
using CourseGlossary.Models;

namespace CourseGlossary.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: /ErrorCategory/
        [HttpGet]
        public ActionResult Index()
        {
            return View(DatabaseService.GetAll<Course, string>(c => c.Name));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Create(course);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    var innerException = exception.InnerException == null ? "" : exception.InnerException.Message;
                    ViewBag.Error = "Couldn't insert new course into database: " + exception.Message + " " + innerException;

                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DatabaseService.Get<Course>(new List<int>{id}));
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Update(course);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = "Couldn't update course in database: " + exception.InnerException;
                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }
	}
}