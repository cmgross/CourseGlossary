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
        public int CourseId { get; set; }

        [AutoIncrement]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2)]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public int Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(200)]
        public string Title { get; set; }
    }
}