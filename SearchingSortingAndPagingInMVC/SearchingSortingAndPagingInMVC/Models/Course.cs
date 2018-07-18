using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchingSortingAndPagingInMVC.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Duraction { get; set; }
        public int Fee { get; set; }
    }
}