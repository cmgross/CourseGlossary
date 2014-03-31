using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseGlossary.DataLayer;

namespace CourseGlossary.Models
{
    public class ChapterViewModel : Chapter
    {
        public List<SelectListItem> Courses { get; set; }
        public List<Chapter> Chapters { get; set; }
        public ChapterViewModel()
        {
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