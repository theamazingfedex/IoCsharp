using System.Web.Mvc;

namespace myOC_WebApp.Controllers
{
    internal interface IHomeController
    {
        ActionResult Index();

        ActionResult About();

        ActionResult Contact();
    }
}