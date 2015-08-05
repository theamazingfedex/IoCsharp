using System;
using myOC_WebApp.Controllers;
using myOC_WebApp.IoC;
using Xunit;
using myOC_WebApp.Interfaces;

namespace myOC_WebApp.Tests.Controllers
{
    public class MyOCTest
    {
        [Theory]
        [InlineData(typeof(ILogger), typeof(Logger))]
        [InlineData(typeof(Logger), typeof(Logger))]
        [InlineData(typeof(ILogger), typeof(ILogger))]
        [InlineData(typeof(IHomeController), typeof(HomeController))]
        public void TestRegisterResolveTransient(Type itype, Type type)
        {
            MyIoC.Register(itype, type);
            Assert.IsAssignableFrom(type, MyIoC.Resolve(itype));
        }

        [Theory]
        [InlineData(typeof(ILogger), typeof(Logger))]
        [InlineData(typeof(Logger), typeof(Logger))]
        [InlineData(typeof(IHomeController), typeof(HomeController))]
        [InlineData(typeof(MyIoC), typeof(MyIoC))]
        public void TestRegisterResolveSingleton(Type itype, Type type)
        {
            // create an instance of the object to set as the singleton
            var implementation = MyIoC.TheObjectOf(type);
            MyIoC.Register(itype, type, implementation);
            Assert.IsAssignableFrom(type, MyIoC.Resolve(itype));
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
