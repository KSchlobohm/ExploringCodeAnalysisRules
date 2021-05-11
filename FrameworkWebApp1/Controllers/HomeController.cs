using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;

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

        public ActionResult Index2(string anotherInput)
        {
            string input = Request.Form["in"];
            XmlDocument d = new XmlDocument();
            XmlElement root = d.CreateElement("root");
            d.AppendChild(root);

            XmlElement allowedUser = d.CreateElement("allowedUser");
            root.AppendChild(allowedUser);

            allowedUser.InnerXml = "alice";

            // If an attacker uses this for input:
            //     some text<allowedUser>oscar</allowedUser>
            // Then the XML document will be:
            //     <root>some text<allowedUser>oscar</allowedUser></root>
            root.InnerXml = input;

            return View();
        }

        public ActionResult Index3(string anotherInput)
        {
            string input = Request.Form["in"];
            byte[] rawAssembly = Convert.FromBase64String(input);
            Assembly.Load(rawAssembly);

            return View();
        }

        public ActionResult Index4(string anotherInput)
        {
            string findTerm = Request.Form["findTerm"];
            Match m = Regex.Match(anotherInput, "^term=" + findTerm);

            return View();
        }
    }
}
