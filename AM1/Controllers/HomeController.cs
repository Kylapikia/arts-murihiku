using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AM1.Models;

namespace AM1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Type"] = "canvas";
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Directory()
        {
            ViewData["Type"] = "Dir";
            return View();
        }
        public IActionResult Events()
        {
            ViewData["Type"] = "Events";
            return View();
        }
        public IActionResult Trail()
        {
            ViewData["Type"] = "trail";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult TermsOfUse()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult SiteMap()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
