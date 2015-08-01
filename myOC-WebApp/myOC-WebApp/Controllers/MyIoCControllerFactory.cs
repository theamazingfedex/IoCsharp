using myOC_WebApp.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Optimization;

namespace myOC_WebApp.Controllers
{
    public class MyIoCControllerFactory : IControllerFactory
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

        protected IController GetControllerInstance(Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            IController controller = (IController)MyIoC.Resolve(controllerType);
            if (controller != null)
            {
                return controller;
            }
            else
            {
                return null;// base;//.GetControllerInstance(controllerType);
            }
        }
    }
}