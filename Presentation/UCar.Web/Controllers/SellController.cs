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
    /// <summary>
    /// Контроллер купле-продажи
    /// </summary>
    [Authorize]
    public class SellController: Controller
    {
        private readonly ICarRepository CarRepository;
        IWebHostEnvironment AppEnvironment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="uploadFile"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="carRepository"></param>
        /// <param name="appEnvironment"></param>
        public SellController(ICarRepository carRepository, IWebHostEnvironment appEnvironment)
        {
            CarRepository = carRepository;
            AppEnvironment = appEnvironment;
        }
<<<<<<< HEAD

        /// <summary>
        /// Возвращает представление
        /// </summary>
        /// <returns></returns>
        [HttpGet]
=======
       [HttpGet]
>>>>>>> d280dfe082d8ee9f0e9525ee3f09984dd524930e
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Приобрести автомобиль
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public IActionResult BuyCar(int id,string owner)
        {
            var car = CarRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            CarRepository.Delete(car);
            car.IsSold = true;
            car.Owner = owner;
            CarRepository.Add(car);
            return View();
        }

        /// <summary>
        /// Откатить изменения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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