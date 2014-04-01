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
    public class GlossaryTermController : Controller
    {
        // GET: /GlossaryTerm/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new GlossaryTermViewModel());
        }

        [HttpGet]
        public ActionResult GetGlossaryTerms(int courseId, int chapterNumber)
        {
            var terms = DatabaseService.GetAll<GlossaryTerm>(c => c.CourseId == courseId && c.ChapterNumber == chapterNumber).ToList();
            return PartialView("_Terms", terms);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new GlossaryTermViewModel());
        }

        [HttpPost]
        public ActionResult Create(GlossaryTerm glossaryTerm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Create(glossaryTerm);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    var innerException = exception.InnerException == null ? "" : exception.InnerException.Message;
                    ViewBag.Error = "Couldn't insert new term into database: " + exception.Message + " " + innerException;

                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new GlossaryTermViewModel(DatabaseService.Get<GlossaryTerm>(new List<int> { id })));
        }

        [HttpPost]
        public ActionResult Edit(GlossaryTerm glossaryTerm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Update(glossaryTerm);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    var innerException = exception.InnerException == null ? "" : exception.InnerException.Message;
                    ViewBag.Error = "Couldn't edit term in database: " + exception.Message + " " + innerException;
                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }
    }
}