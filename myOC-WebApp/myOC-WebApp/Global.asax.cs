using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using myOC_WebApp.Controllers;
using myOC_WebApp.IoC;
using myOC_WebApp.Models;
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
            RegisterDependencies();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(typeof(MyIoCControllerFactory));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //This is where the ControllerFactory is supposed to be registered, I believe
        }

        protected void RegisterDependencies()
        {
            MyIoC.Register<ILogger, Logger>();
            MyIoC.Register<IHomeController, HomeController>();
            MyIoC.Register<IAccountController, AccountController>();
            MyIoC.Register<IManageController, ManageController>();
            MyIoC.Register<IController, Controller>();
            //MyIoC.Register<AccountController, AccountController>();
            //MyIoC.Register<ManageController, ManageController>();
            //MyIoC.Register<HomeController, HomeController>();

            MyIoC.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>();
            MyIoC.Register<UserManager<ApplicationUser>, ApplicationUserManager>();
            MyIoC.Register<IUser, UserManager<ApplicationUser>>();
            MyIoC.Register<IdentityUser, ApplicationUser>();
        }
    }
}
