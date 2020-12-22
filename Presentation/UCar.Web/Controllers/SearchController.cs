using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UCar.Web.Controllers
{
    /// <summary>
    /// контроллер поиска
    /// </summary>
    public class SearchController : Controller
    {
        private readonly ICarRepository carRepository;

        /// <summary>
        /// Конструктор контроллера поиска
        /// </summary>
        /// <param name="carRepository"></param>
        public SearchController(ICarRepository carRepository)
        {
            this.carRepository=carRepository;
        }

        /// <summary>
        /// Возвращает список автомобилей с помощью метода GetBuQuery из CarRepository
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IActionResult Index(string query)
        {
            var cars = carRepository.GetByTitle(query).Where(c => c.IsConfirned == true&c.IsSold==false).ToArray(); ;
            return View(cars);
        }
    }
}
