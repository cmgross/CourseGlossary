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
    }
}