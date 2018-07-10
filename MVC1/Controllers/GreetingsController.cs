using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class GreetingsController : Controller
    {
        // GET: Greetings
        public ActionResult Index()
        {
            ViewData["VDTS"] = DateTime.Now;
            ViewBag.VBTS = DateTime.Now;

            return View();
        }

        public string Hello(string name) {
            return $"My name is {name}";
        }
    }
}