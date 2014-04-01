using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace CourseGlossary.Models
{
    public class Chapter
    {
        [Display(Name = "Course")]
        [System.ComponentModel.DataAnnotations.Required]
        [ForeignKey(typeof(Course), OnDelete = "CASCADE")]
        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue,ErrorMessage = "Course required.")]
        public int CourseId { get; set; }

        [AutoIncrement]
        public int Id { get; set; }

        [Display(Name = "Chapter Number")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, 99)]
        public int ChapterNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Title { get; set; }
    }
}