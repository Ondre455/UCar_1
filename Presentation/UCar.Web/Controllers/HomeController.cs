using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UCar.Web.Models;

namespace UCar.Web.Controllers
{
    /// <summary>
    /// Контроллер домашней страницы
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository carRepository;

        /// <summary>
        /// Конструктор для контроллера домашней страницы
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="car"></param>
        public HomeController(ILogger<HomeController> logger, ICarRepository car)
        {
            this.carRepository = car;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает представление домашней страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var cars = carRepository.GetAll().Where(c=>c.IsConfirned==true&c.IsSold==false).ToArray() ;
            return View(cars);
        }

        /// <summary>
        /// Возвращает окно приватности
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Возвращает окно ошибки
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
