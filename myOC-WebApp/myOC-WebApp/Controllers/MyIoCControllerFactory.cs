using myOC_WebApp.IoC;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace myOC_WebApp.Controllers
{
    public class MyIoCControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            controllerName = string.Concat("myOC_WebApp.Interfaces.I", controllerName, "Controller");
            System.Diagnostics.Debug.WriteLine("++++CREATINGCONTROLLER " + controllerName);
            Type controllerType = Type.GetType(controllerName);
            return (IController)MyIoC.Resolve(controllerType);
        }
    }
}