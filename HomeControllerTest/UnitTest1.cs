using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC1.Controllers;

namespace HomeControllerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController homeController = new HomeController();
            String result = homeController.Hello("Bob");
        }
    }
}
