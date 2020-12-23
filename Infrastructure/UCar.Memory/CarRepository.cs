using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UCar.Memory
{
    /// <summary>
    /// Класс хранилища Автомобилей;
    /// Реализует соответствующий интерфейс
    /// По паттерну Singletone существует только 1 на весь проект
    /// </summary>
    public class CarRepository : ICarRepository
    {
        private List<Car> cars = new List<Car>();

        /// <summary>
        /// Создает РЕпозиторий машин
        /// </summary>
        public CarRepository()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Cars.txt");
            if (File.Exists(path))
            {
                cars = new List<Car>();
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        cars.Add(new Car(line));
                }
            }
            else
            {
                cars = new List<Car>
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
                foreach (var e in cars)
                {
                    File.WriteAllText(path, e.ToString());
                }
            }
        }

        /// <summary>
        /// должен возвращать список автомобилей по названию
        /// </summary>
        /// <param name="TitlePart"></param>
        /// <returns></returns>
        public Car[] GetByTitle(string TitlePart)
        {
            if (TitlePart == null) return cars.ToArray();
            return cars
                .Where(c => c.Model.Contains(TitlePart)
                    || c.Description.Contains(TitlePart))
                .ToArray();        
        }

        /// <summary>s
        /// добавляет автомобиль в репозиторий
        /// </summary>
        /// <param name="car"></param>
        public void Add (Car car)
        {
            cars.Add(car);
            string path = Path.Combine(Environment.CurrentDirectory, "Cars.txt");
            File.AppendText(path).WriteLine(car.ToString());
        }
<<<<<<< HEAD

        /// <summary>
        /// Возвращает id последнего автомобиля
        /// </summary>
        /// <returns></returns>
        public int GetLastCarIDValue()
=======
        public int FormCarID()
>>>>>>> d280dfe082d8ee9f0e9525ee3f09984dd524930e
        {
            return cars.Last().ID.IDValue*cars.Count();
        }

        /// <summary>
        /// возвращает все автомобили
        /// </summary>
        /// <returns></returns>
        public Car[] GetAll()
        {
            return cars.ToArray();
        }

        /// <summary>
        /// удаляет автомобиль из репозитория
        /// </summary>
        /// <param name="car">Этот автомобиль будет удален</param>
        public void Delete(Car car)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Cars.txt");
            cars.Remove(car);
            File.Delete(path);
            var list = new List<string>();
            foreach (var e in cars)
            {
                list.Add(e.ToString());
            }
            File.AppendAllLines(path, list);
        }
    }
}
