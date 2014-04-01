using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CourseGlossary.DataLayer;
using CourseGlossary.Models;
using ServiceStack.Mvc;

namespace CourseGlossary.Controllers
{
    [Authorize]
    public class ChapterController : Controller
    {
        // GET: /Chapter/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ChapterViewModel());
        }

        // GET: /Chapter/GetCourseChapters/{id}
        [HttpGet]
        public ActionResult GetCourseChapters(int id)
        {
            var chapters = DatabaseService.GetAll<Chapter>(c => c.CourseId == id).ToList();
            return PartialView("_Chapters", chapters);
        }

        [HttpGet]
        public JsonResult GetCourseChaptersJson(int id)
        {
            var chapters = DatabaseService.GetAll<Chapter>(c => c.CourseId == id).ToList();
            return new JsonResult
            {
                Data = chapters.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ChapterViewModel());
        }

        [HttpPost]
        public ActionResult Create(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Create(chapter);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    var innerException = exception.InnerException == null ? "" : exception.InnerException.Message;
                    ViewBag.Error = "Couldn't insert new chapter into database: " + exception.Message + " " + innerException;

                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new ChapterViewModel(DatabaseService.Get<Chapter>(new List<int> { id })));
        }

        [HttpPost]
        public ActionResult Edit(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseService.Update(chapter);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    var innerException = exception.InnerException == null ? "" : exception.InnerException.Message;
                    ViewBag.Error = "Couldn't edit chapter in database: " + exception.Message + " " + innerException;
                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ServiceStackJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }
    }
}