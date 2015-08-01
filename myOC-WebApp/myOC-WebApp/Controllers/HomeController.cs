using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myOC_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Controller controller;

        public HomeController(Controller controller)
        {
            this.controller = controller;
        }

        public ActionResult Index()
        {
            this.ViewData.Model = this.controller;
            return View();
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