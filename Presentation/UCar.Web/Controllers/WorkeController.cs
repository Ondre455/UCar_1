using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCar.Web.Controllers
{
    [Authorize(Roles="Сотрудник")]
    public class WorkeController: Controller
    {
        private ICarRepository carRepository;
        public WorkeController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IActionResult OperationComplited ()
        {
            return View();
        }
        public IActionResult DoConfirmCar()
        {
            return View(carRepository.GetAll().Where(c => c.IsConfirned == false).ToArray());
        }
        public IActionResult Confirm(int id)
        {
            var car=carRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            carRepository.Delete(car);
            car.IsConfirned = true;
            car.Owner = "Автосалон";
            carRepository.Add(car);
            return LocalRedirect("~/Worke/OperationComplited");
        }
        public IActionResult Delete(int id)
        {
            var car = carRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            carRepository.Delete(car);
            return LocalRedirect("~/Worke/OperationComplited");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SolledCars()
        {
            return View(carRepository.GetAll().Where(c => c.IsSold == true).ToArray());
        }
    }
}
