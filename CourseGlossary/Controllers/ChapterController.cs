﻿using System;
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
                     //DatabaseService.Create(chapter);
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
	}
}