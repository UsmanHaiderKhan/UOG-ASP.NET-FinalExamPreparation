using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Assignment_3.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=constr")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }

}