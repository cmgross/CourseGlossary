using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseGlossary.DataLayer;

namespace CourseGlossary.Models
{
    public class HomeViewModel
    {
        public List<SelectListItem> Courses { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public HomeViewModel()
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