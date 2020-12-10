using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    public class CarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public Car[] GetAllByQuery(string query)
        {
            return carRepository.GetByTitle(query);
        }
    }
}
