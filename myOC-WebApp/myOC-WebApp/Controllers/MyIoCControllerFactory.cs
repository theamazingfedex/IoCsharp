using myOC_WebApp.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myOC_WebApp.Controllers
{
    public class MyIoCControllerFactory
    {
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
                return base.GetControllerInstance(controllerType);
            }
        }
    }
}