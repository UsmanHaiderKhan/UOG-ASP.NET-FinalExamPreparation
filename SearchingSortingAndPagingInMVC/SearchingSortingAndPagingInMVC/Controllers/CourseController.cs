using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchingSortingAndPagingInMVC.Models;
using PagedList;

namespace SearchingSortingAndPagingInMVC.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Course
        //Searching





        public ActionResult Index(string searchString)
        {
            var courses = from c in db.Course
                          select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CourseName.Contains(searchString));
                courses = courses.Where(c => c.CourseName == searchString);
                courses = courses.Where(c => c.CourseName.Contains(searchString));
                courses.Where(c => c.CourseName.Contains(searchString) || c.Duraction == searchString);
            }
            return View(courses);



        }


        // GET: Course
        //Sorting
        public ActionResult Sorting(string sortOrder)
        {



            ViewBag.CourseNameSort = string.IsNullOrEmpty(sortOrder)
            ? "CourseName_desc" : "";
            ViewBag.DuractionSort = sortOrder == "Duraction"
            ? "Duraction_desc " : "Duraction";
            ViewBag.FeeSort = sortOrder == "Fee" ? "Fee_desc " : "Fee";

            var courses = from c in db.Course
                          select c;


            switch (sortOrder)
            {
                case "CourseName_desc":
                    courses = courses.OrderByDescending(c => c.CourseName);
                    break;
                case "Duraction":
                    courses = courses.OrderBy(c => c.Duraction);
                    break;

                case "Fee_desc":
                    courses = courses.OrderByDescending(c => c.Fee);
                    break;

            }
            return View(courses);
        }
        //Paging 
        public ActionResult Paging(int? page)
        {
            var courses = from c in db.Course
                          orderby c.CourseId
                          select c;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(courses.ToPagedList(pageNumber, pageSize));
        }
        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,Duraction,Fee")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,Duraction,Fee")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Course.Find(id);
            db.Course.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
