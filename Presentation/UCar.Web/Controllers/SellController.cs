using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UCar.Web.Controllers
{
    [Authorize]
    public class SellController: Controller
    {
        private readonly ICarRepository CarRepository;
        IWebHostEnvironment AppEnvironment;
        [HttpPost]
        public IActionResult Index(string Model,string Description,int Price, IFormFile uploadFile,string owner)
        {
            string path = "/img/" + uploadFile.FileName;
            // сохраняем файл в папку img в каталоге wwwroot
            using (var fileStream = new FileStream(AppEnvironment.WebRootPath + path, FileMode.Create))
            {
                 uploadFile.CopyTo(fileStream);
            }
            var car = new Car(Model, Description,Price, new Car.CarID(CarRepository.FormCarID() + 1),path,false,false,owner);
            CarRepository.Add(car);
            return LocalRedirect("~/Home");
        }
        public SellController(ICarRepository carRepository, IWebHostEnvironment appEnvironment)
        {
            CarRepository = carRepository;
            AppEnvironment = appEnvironment;
        }
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BuyCar(int id,string owner)
        {
            var car = CarRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            CarRepository.Delete(car);
            car.IsSold = true;
            car.Owner = owner;
            CarRepository.Add(car);
            return View();
        }
        public IActionResult Undo(int id)
        {
            var car = CarRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            CarRepository.Delete(car);
            car.IsSold = false;
            car.Owner = "Автосалон";
            CarRepository.Add(car);
            return RedirectToAction("SolledCars","Worke");
        }
    }
}