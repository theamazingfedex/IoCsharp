using myOC_WebApp.Interfaces;
using myOC_WebApp.IoC;
using System.Web.Mvc;

namespace myOC_WebApp.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            this._logger = logger;
            _logger.Log("======== Started HomeController using injected constructor");
        }
        public HomeController() : this((ILogger)MyIoC.Resolve(typeof(ILogger))){ }
        public ActionResult Index()
        {
            ViewBag.Message = "The All-Glorious Index Page";
            _logger.Log("Visited the index through home controller");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            _logger.Log("Visited the About page through home controller");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}