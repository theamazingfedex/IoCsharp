using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using myOC_WebApp;
using myOC_WebApp.Controllers;
using myOC_WebApp.IoC;
using Xunit;


namespace myOC_WebApp.Tests.Controllers
{
    public class MyOCTest
    {
        [Fact]
        public void RegisterTest()
        {
            AccountController ctrl = new AccountController();
            MyIoC.Register<Controller, AccountController>(ctrl);
            //Assert.Equal("potatoes!!", potatoes);
        }
        [Fact]
        public void ResolveTest()
        {
            //Assert.Equal("cheese", MyIoC.Resolve());
        }

    }

    // The tests below are for testing the asp.net service. Saving them for later
    //
    //
    //public class HomeControllerTest
    //{
    //    [Fact]
    //    public void Index()
    //    {
    //        HomeController controller = new HomeController();

    //        ViewResult result = controller.Index() as ViewResult;

    //        Assert.NotNull(result);
    //    }
    //    [Theory]
    //    [InlineData(3)]
    //    [InlineData(5)]
    //    // [InlineData(6)]
    //    public void MyFirstTheory(int value)
    //    {
    //        Assert.True(IsOdd(value));
    //    }

    //    bool IsOdd(int value)
    //    {
    //        return value % 2 == 1;
    //    }

    //    [Fact]
    //    public void About()
    //    {
    //        HomeController controller = new HomeController();

    //        ViewResult result = controller.About() as ViewResult;

    //        Assert.Equal("Your application description page.", result.ViewBag.Message);
    //    }

    //    [Fact]
    //    public void Contact()
    //    {
    //        HomeController controller = new HomeController();

    //        ViewResult result = controller.Contact() as ViewResult;

    //        Assert.NotNull(result);
    //    }
    //}
}
