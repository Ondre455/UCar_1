using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCar.Web.Controllers
{
    /// <summary>
    /// контроллер для сотрудников
    /// </summary>
    [Authorize(Roles = "Сотрудник")]
    public class WorkeController: Controller
    {
        private ICarRepository carRepository;

        /// <summary>
        /// Конструктор для контроллера
        /// </summary>
        /// <param name="carRepository"></param>
        public WorkeController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        /// <summary>
        /// Завершение операции
        /// </summary>
        /// <returns></returns>
        public IActionResult OperationComplited ()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Список неподтвержденных авто</returns>
        public IActionResult DoConfirmCar()
        {
            return View(carRepository.GetAll().Where(c => c.IsConfirned == false).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Подтверждение автомобиля</returns>
        public IActionResult Confirm(int id)
        {
            var car=carRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            carRepository.Delete(car);
            car.IsConfirned = true;
            car.Owner = "Автосалон";
            carRepository.Add(car);
            return LocalRedirect("~/Worke/OperationComplited");
        }

        /// <summary>
        /// Удаление машиины из репозитория
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var car = carRepository.GetAll().Where(c => c.ID.IDValue == id).ToArray()[0];
            carRepository.Delete(car);
            return LocalRedirect("~/Worke/OperationComplited");
        }

        /// <summary>
        /// Возвращает представление
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Список проданных машин
        /// </summary>
        /// <returns></returns>
        public IActionResult SolledCars()
        {
            return View(carRepository.GetAll().Where(c => c.IsSold == true).ToArray());
        }
    }
}
