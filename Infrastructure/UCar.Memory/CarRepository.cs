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
            var path = @"D:\\UCar\UCar_1\Cars.txt";
            cars = new List<Car>();
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    cars.Add(new Car(line));
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

        /// <summary>
        /// добавляет автомобиль в репозиторий
        /// </summary>
        /// <param name="car"></param>
        public void Add (Car car)
        {
            cars.Add(car);
            
        }

        /// <summary>
        /// Возвращает id последнего автомобиля
        /// </summary>
        /// <returns></returns>
        public int GetLastCarIDValue()
        {
            return cars.Last().ID.IDValue;
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
            cars.Remove(car);
        }
    }
}
