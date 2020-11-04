using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About ABC Supermarket";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "ABC Supermarket";

            return View();
        }
    }
}