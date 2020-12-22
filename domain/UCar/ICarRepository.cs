using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    /// <summary>
    /// интерфейс для репозитория автомобилей
    /// </summary>
    public interface ICarRepository
    {
        /// <summary>
        /// должен возвращать список автомобилей по названию
        /// </summary>
        /// <param name="TitlePart"></param>
        /// <returns></returns>
        Car[] GetByTitle(string TitlePart);

        /// <summary>
        /// добавляет автомобиль в репозиторий
        /// </summary>
        /// <param name="car"></param>
        void Add(Car car);

        /// <summary>
        /// Возвращает id последнего автомобиля
        /// </summary>
        /// <returns></returns>
        int GetLastCarIDValue();

        /// <summary>
        /// возвращает все автомобили
        /// </summary>
        /// <returns></returns>
        Car[] GetAll();

        /// <summary>
        /// удаляет автомобиль из репозитория
        /// </summary>
        /// <param name="car">Этот автомобиль будет удален</param>
        void Delete(Car car);
    }
}
