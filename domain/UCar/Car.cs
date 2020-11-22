﻿using System;
using System.Collections.Generic;

namespace UCar
{
    public class Car
    {
        public CarID ID { get; }
        public string Model { get; }
        public string Description { get; }
        public List<Cathegory> Cathegories;

        public Car(string model, string description, CarID id)
        {
            Model = model;
            Description = description;
            ID = id;
        }

        public void AddCathegory(Cathegory cathegory)
        {
            Cathegories.Add(cathegory);
            cathegory.cars.Add(this);
        }

        public override bool Equals(object obj)
        {
            Car OtherCar = (Car)obj;
            return this.ID == OtherCar.ID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public class CarID
        {
            public readonly int IDValue;

            public CarID(int id)
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
