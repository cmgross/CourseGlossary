using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseGlossary.DataLayer;

namespace CourseGlossary.Models
{
    public class GlossaryTermViewModel : GlossaryTerm
    {
        public List<SelectListItem> Courses { get; set; }
        public List<SelectListItem> Chapters { get; set; }

        public GlossaryTermViewModel()
        {
            Chapters = new List<SelectListItem>();

            var courses = new List<Course> { new Course() };
            courses.AddRange(DatabaseService.GetAll<Course, int>(c => c.Id));
            Courses = courses.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
        }
    }
}