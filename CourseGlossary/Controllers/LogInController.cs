using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CourseGlossary.Models;

namespace CourseGlossary.Controllers
{
    public class LogInController : Controller
    {
        [HttpGet]// GET: /LogIn/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Credentials model, string returnUrl)
        {
            if (!ModelState.IsValid) return View();
            if (FormsAuthentication.Authenticate(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            ModelState.AddModelError("", "Incorrect username or password");
            return View();
        }
    }
}