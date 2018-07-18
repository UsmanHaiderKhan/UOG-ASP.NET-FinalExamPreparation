using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TempDataSession.Models;

namespace TempDataSession.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisitorTemp(Visitor visitor)
        {
            HttpCookie cookie = new HttpCookie("Visitor");
            cookie.Value = visitor.Name;
            HttpContext.Response.Cookies.Add(cookie);
            // Non-Persistance Cookie
            cookie.Expires = DateTime.Now.AddDays(3);//This is form Persistance Cookie

            return View();
        }
    }
}