using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCar.Web.Controllers
{
    [Authorize]
    public class SellController: Controller
    {
        private readonly ICarRepository CarRepository;
        [HttpPost]
        public IActionResult Index(string Model,string Description,int Price)
        {
            var car = new Car(Model, Description,Price, new Car.CarID(CarRepository.Count() + 1));
            CarRepository.Add(car);
            return LocalRedirect("~/Home");
        }
        public SellController(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
