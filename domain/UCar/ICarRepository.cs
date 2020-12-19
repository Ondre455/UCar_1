using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    public interface ICarRepository
    {
        Car[] GetByTitle(string TitlePart);
        void Add(Car car);
        int GetLastCarIDValue();
        Car[] GetAll();
        void Delete(Car car);
    }
}
