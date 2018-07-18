using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }
        public string Address { get; set; }
        public string Workspeciality { get; set; }
        public decimal Income { get; set; }
        public long MobileNo { get; set; }
    }
}