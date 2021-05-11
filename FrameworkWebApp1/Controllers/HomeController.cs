using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkWebApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string anotherInput)
        {
            ViewBag.Title = "Home Page";

            try
            {
                string input = Request.Form["in"];
                var p = Process.Start(input);
                p.WaitForExit();
            }
            catch
            {

            }

            return View();
        }
    }
}
