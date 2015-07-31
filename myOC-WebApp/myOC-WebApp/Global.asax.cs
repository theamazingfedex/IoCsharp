using myOC_WebApp.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace myOC_WebApp
{ 
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(typeof (MyControllerFactory));
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //This is where the ControllerFactory is supposed to be registered, I believe
        }
    }

    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(IController controller)
        {
            throw new NotImplementedException();
        }
    }
}
