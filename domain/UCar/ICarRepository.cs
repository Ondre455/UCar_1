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
<<<<<<< HEAD

        /// <summary>
        /// Возвращает id последнего автомобиля
        /// </summary>
        /// <returns></returns>
        int GetLastCarIDValue();

        /// <summary>
        /// возвращает все автомобили
        /// </summary>
        /// <returns></returns>
=======
        int FormCarID();
>>>>>>> d280dfe082d8ee9f0e9525ee3f09984dd524930e
        Car[] GetAll();

        /// <summary>
        /// удаляет автомобиль из репозитория
        /// </summary>
        /// <param name="car">Этот автомобиль будет удален</param>
        void Delete(Car car);
    }
}
