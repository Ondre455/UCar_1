using System;
using System.Linq;

namespace UCar.Memory
{
    public class CarRepository : ICarRepository
    {
        private readonly Car[] cars = new[]
        {
            new Car("Toyota Corolla","Недорогая, практичная, надежная", new Car.CarID(1)),
            new Car("BMW M5","Классная, но сломанная",new Car.CarID(2)),
            new Car("Touota Land Cruiser 200","Почти новый, внедорожник", new Car.CarID(3))
        };

        public Car[] GetByTitle(string TitlePart)
        {
            return cars
                .Where(c => c.Model.Contains(TitlePart))
                .ToArray();        
        }
        public Car[] GetAllByCathegory(Cathegory cathegory)
        {
            return cars
                .Where(c => c.Cathegories.Contains(cathegory))
                .ToArray();
        }
    }
}
