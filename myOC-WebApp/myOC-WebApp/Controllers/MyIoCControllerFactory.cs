using myOC_WebApp.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Optimization;
using System.ComponentModel;

namespace myOC_WebApp.Controllers
{
    public class MyIoCControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = Type.GetType(string.Concat("myOC_WebApp.Controllers.I", controllerName, "Controller"));
            System.Diagnostics.Debug.WriteLine("++++CREATINGCONTROLLER" + controllerType.Name);
            return (IController)MyIoC.Resolve(controllerType);
            //return new HomeController((ILogger)MyIoC.Resolve(typeof(ILogger)));
            //return new HomeController((ILogger)MyIoC.Resolve(controllerName));
        }
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public override void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}