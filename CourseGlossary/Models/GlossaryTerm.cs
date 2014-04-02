using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace CourseGlossary.Models
{
    public class GlossaryTerm
    {
        [Display(Name = "Course")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue, ErrorMessage = "Course required.")]
        public int CourseId { get; set; }

        [Display(Name = "Chapter Number")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(1, 99)]
        public int ChapterNumber { get; set; }

        [AutoIncrement]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        public string Term { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Page { get; set; }
    }
}