using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UCar.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly CarService CarService;

        public SearchController(CarService carService)
        {
            CarService = carService;
        }
        public IActionResult Index(string query)
        {
            var cars = CarService.GetAllByQuery(query);
            return View(cars);
        }
    }
}
