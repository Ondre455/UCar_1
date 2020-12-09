using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    public class CarService
    {
        public Car[] GetAllByQuery(string query)
        {
            return new[] { new Car("", "", new Car.CarID(14)) };
        }
    }
}
