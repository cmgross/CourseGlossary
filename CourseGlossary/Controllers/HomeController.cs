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
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpGet]
        public JsonResult SearchGlossaryTerms(string searchTerm, int courseId)
        {
            var results = DatabaseService.GetAll<GlossaryTerm>(c => c.CourseId == courseId && c.Term.ToLower().Contains(searchTerm.ToLower())).ToList();
            return new JsonResult
            {
                Data = results.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
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