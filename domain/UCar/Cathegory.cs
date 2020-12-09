using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    public class Cathegory
    {
        public CathegoryID ID { get; }
        public string Name { get; }
        public List<Car> cars;

        public Cathegory(string name, CathegoryID id)
        {
            Name = name;
            ID = id;
        }
        public void AddCar(Car car)
        {
            car.AddCathegory(this);
        }
        public override bool Equals(object obj)
        {
            var otherCathegory = (Cathegory)obj;
            return this.ID == otherCathegory.ID;
        }

        public static bool operator ==(Cathegory cathegory, string Str)
        {
            return cathegory.Name == Str;
        }

        public static bool operator !=(Cathegory cathegory, string Str)
        {
            return cathegory.Name != Str;
        }

        public class CathegoryID
        {
            public readonly int IDValue;

            public CathegoryID(int id)
            {
                IDValue = id;
            }

            public override string ToString()
            {
                return IDValue.ToString();
            }
        }
    }
}
