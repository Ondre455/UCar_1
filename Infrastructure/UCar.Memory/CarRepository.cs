using System;
using System.Collections.Generic;
using System.Linq;

namespace UCar.Memory
{
    public class CarRepository : ICarRepository
    {
        private  List<Car> cars = new List<Car>        
        {
            new Car("Toyota Corolla","Недорогая, практичная, надежная",1000000, new Car.CarID(1)),
            new Car("BMW M5","Классная, но сломанная",1000000,new Car.CarID(2)),
            new Car("Toyota Land Cruiser 200","Почти новый, внедорожник",1000000, new Car.CarID(3)),
            new Car("Lada 2109","Старое ведро", 1000000,new Car.CarID(4)),
            new Car("Lada Vesta","Топ за свои деньги",1000000, new Car.CarID(5)),
            new Car("Toyota Land Cruiser 100","Хороший, проходимый",1000000, new Car.CarID(6)),
            new Car("Mercedes w140","Настоящий кабан",1000000, new Car.CarID(7)),
            new Car("Mercedes w140","Рубль 40",1000000, new Car.CarID(8)),
        };

        public Car[] GetByTitle(string TitlePart)
        {
            return cars
                .Where(c => c.Model.Contains(TitlePart)
                    || c.Description.Contains(TitlePart))
                .ToArray();        
        }
        public Car[] GetAllByCathegory(Cathegory cathegory)
        {
            return cars
                .Where(c => c.Cathegories.Contains(cathegory))
                .ToArray();
        }
        public void Add (Car car)
        {
            cars.Add(car);
        }
        public int Count()
        {
            return cars.Count;
        }
    }
}
