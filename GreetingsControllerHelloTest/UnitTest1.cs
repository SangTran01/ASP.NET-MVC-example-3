using MVC1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVC1.Models;
using System.Collections.Generic;

namespace GreetingsControllerHelloTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GreetingsController greetingsController = new GreetingsController();
            string result = greetingsController.Hello("Bob");

            Assert.AreEqual("My name is Bob", result);
        }

        [TestMethod]
        public void CarControllerIndexTest()
        {
            CarController carController = new CarController();

            ActionResult actionResult = carController.Index();
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult));
            ViewResult viewResult = actionResult as ViewResult;
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Car>));
            List<Car> cars = viewResult.Model as List<Car>;
            Assert.AreEqual(3, cars.Count);

            Car car = cars.Find(c => c.ID == 1);
            Assert.AreEqual("Mustang", car.Model);
            
        }

        [TestMethod]
        public void CarControllerDetailsTest()
        {
            CarController carController = new CarController();
            ActionResult actionResult = carController.Details(1);
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult));

            ViewResult viewResult = actionResult as ViewResult;
            Assert.IsInstanceOfType(viewResult.Model, typeof(VMCar));
            VMCar car = viewResult.Model as VMCar;
            Assert.AreEqual("Bill Ford", car.OwnerName);
        }
    }
}
