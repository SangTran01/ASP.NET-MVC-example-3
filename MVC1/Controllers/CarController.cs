using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { ID = 1, Make = "Ford", Model = "Mustang", Year = 2015, Email = "mustang@ford.com" },
            new Car { ID = 2, Make = "Chevrolet", Model = "Corvette", Year = 2016, Email = "corvette@gm.com" },
            new Car { ID = 3, Make = "Tesla", Model = "Roadster", Year = 2017, Email = "roadster@tesla.com" }
        };

        private static List<Owner> owners = new List<Owner>
        {
            new Owner { ID = 1, FirstName = "Bill", LastName = "Ford"},
            new Owner { ID = 2, FirstName = "Mary", LastName = "Barra"},
            new Owner { ID = 3, FirstName = "Elon", LastName = "Musk"}
        };

        // GET: Car
        public ActionResult Index()
        {
            return View(cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            int index = cars.FindIndex(c => c.ID == id);

            if (index == -1)
            {
                return View("Error", new ErrorViewModel { Description = $"Car with ID {id} not found." });
            }

            Owner owner = owners[index];
            Car car = cars[index];
            VMCar vmCar = new VMCar { ID = car.ID, Make = car.Make, Model = car.Model, Year = car.Year, Email = car.Email };
            vmCar.OwnerName = $"{owner.FirstName} {owner.LastName}";
            return View(vmCar);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(Car car)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    cars.Add(car);
                    return RedirectToAction("Index");
                }
                else
                    return View(car);

            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            var car = cars.Find(c => c.ID == id);
            if (car == null)
            {
                return View("Error", new ErrorViewModel { Description = $"Car with ID {id} not found." });
            }

            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //find car in cars with same id
                    int index = cars.FindIndex(c => c.ID == id);
                    cars[index] = car;
                    return RedirectToAction("Index");
                }
                else
                    return View(car);
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            int index = cars.FindIndex(c => c.ID == id);
            if (index == -1)
            {
                return View("Error", new ErrorViewModel { Description = $"Car with ID {id} not found." });
            }
            return View(cars[index]);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                // TODO: Add delete logic here
                int index = cars.FindIndex(c => c.ID == id);
                cars.RemoveAt(index);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
