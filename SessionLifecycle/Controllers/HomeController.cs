using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLifecycle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var blah = new MySessionProvider.SessionProvider();
            return View();
        }

        [HttpGet]
        public string SetSession()
        {
            Session["test"] = DateTime.Now;

            return "session set";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}