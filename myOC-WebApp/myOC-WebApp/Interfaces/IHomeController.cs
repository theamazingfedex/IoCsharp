using System.Web.Mvc;

namespace myOC_WebApp.Interfaces
{
    public interface IHomeController
    {
        ActionResult Index();

        ActionResult About();

        ActionResult Contact();
    }
}