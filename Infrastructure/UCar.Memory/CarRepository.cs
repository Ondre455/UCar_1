using System;
using System.Collections.Generic;
using System.Linq;

namespace UCar.Memory
{
    public class CarRepository : ICarRepository
    {
        private readonly  List<Car> cars = new List<Car>        
        {
            new Car("Toyota Corolla","Недорогая, практичная, надежная",1000000, new Car.CarID(1),"/img/Toyota.jpg",true,true, "user@mail.ru"),
            new Car("BMW M5","Классная, но сломанная",1000000,new Car.CarID(2),"/img/BMW M5.jpg",true,false,"Автосалон"),
            new Car("Toyota Land Cruiser 200","Почти новый, внедорожник",1000000, new Car.CarID(3),"/img/Toyota Land Cruiser 200.jpg",true,false,"Автосалон"),
            new Car("Lada 2109","Старое ведро", 1000000,new Car.CarID(4),"/img/Lada 2109.jpg",true,false,"Автосалон"),
            new Car("Lada Vesta","Топ за свои деньги",1000000, new Car.CarID(5),"/img/Lada Vesta.jpg",true,false,"Автосалон"),
            new Car("Toyota Land Cruiser 100","Хороший, проходимый",1000000, new Car.CarID(6),"/img/Toyota Land Cruiser 100.jpg",false,false,"user@mail.ru"),
            new Car("Mercedes w140","Настоящий кабан",1000000, new Car.CarID(7),"/img/Mercedes w140.1.jpg",false,false,"user@mail.ru"),
            new Car("Mercedes w140","Рубль 40",1000000, new Car.CarID(8),"/img/Mercedes w140.2.jpg",true,false,"Автосалон"),
        };

        public Car[] GetByTitle(string TitlePart)
        {
            if (TitlePart == null) return cars.ToArray();
            return cars
                .Where(c => c.Model.Contains(TitlePart)
                    || c.Description.Contains(TitlePart))
                .ToArray();        
        }
        public void Add (Car car)
        {
            cars.Add(car);
        }
        public int GetLastCarIDValue()
        {
            return cars.Last().ID.IDValue;
        }
        public Car[] GetAll()
        {
            return cars.ToArray();
        }
        public void Delete(Car car)
        {
            cars.Remove(car);
        }
    }
}
