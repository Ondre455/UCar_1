using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UCar.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarRepository carRepository;

        public SearchController(ICarRepository carRepository)
        {
            this.carRepository=carRepository;
        }
        public IActionResult Index(string query)
        {
            var cars = carRepository.GetByTitle(query).Where(c => c.IsConfirned == true&c.IsSold==false).ToArray(); ;
            return View(cars);
        }
    }
}
