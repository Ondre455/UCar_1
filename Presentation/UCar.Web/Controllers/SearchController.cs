using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UCar.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarRepository CarRepository;

        public SearchController(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }
        public IActionResult Index(string query)
        {
            var cars = CarRepository.GetByTitle(query);
            return View(cars);
        }
    }
}
