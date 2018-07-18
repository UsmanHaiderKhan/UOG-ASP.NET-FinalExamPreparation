using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewBagData.Models;

namespace ViewBagData.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentList()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ Id= 1, FullName= "Usman Haider Khan", RollNo = 76,FullAddress = "FarooqAbad"},
                new Student(){ Id= 2, FullName= "M Usman Gujjar", RollNo = 77 ,FullAddress = "FarooqAbad"},
                new Student(){ Id= 3, FullName= "Imran khan", RollNo = 999 ,FullAddress = "bani galla"},
                new Student(){ Id= 4, FullName= "Zohaib Ishfaq", RollNo = 70 ,FullAddress = "Faslabad"},
                new Student(){ Id= 5, FullName= "Hafiz Hanan", RollNo = 53 ,FullAddress = "Lahore"},
                new Student(){ Id= 5, FullName= "Matti-ur-Rehman", RollNo = 89 ,FullAddress = "Lahore"},
                };
            ViewBag.TotalStudents = students.Count();
            ViewBag.TotalStudent = students;
            return View();

        }
    }
}