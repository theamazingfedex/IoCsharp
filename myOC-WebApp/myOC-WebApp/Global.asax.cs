using myOC_WebApp.Controllers;
using myOC_WebApp.IoC;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace myOC_WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterDependencies();
            ControllerBuilder.Current.SetControllerFactory(typeof(MyIoCControllerFactory));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void RegisterDependencies()
        {
            MyIoC.Register<ILogger, Logger>();
            MyIoC.Register<IHomeController, HomeController>();
            MyIoC.Register<IAccountController, AccountController>();
            MyIoC.Register<IManageController, ManageController>();
        }
    }
}
