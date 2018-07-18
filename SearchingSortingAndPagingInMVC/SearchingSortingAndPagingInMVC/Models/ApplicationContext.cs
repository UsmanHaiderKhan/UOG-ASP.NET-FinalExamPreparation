using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchingSortingAndPagingInMVC.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Course> Course { get; set; }
    }
}