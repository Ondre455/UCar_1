using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCar
{
    public class Car
    {
        public string Image { get; }
        public CarID ID { get; }
        [Display(Name="Модель")]
        public string Model { get; }
        [Display(Name = "Описание")]
        public string Description { get; }
        [Display(Name = "Цена ")]
        public int Price { get; }
        public bool IsConfirned { get; set; }
        public bool IsSold { get; set; }
        [Display(Name ="Владелец")]
        public string Owner { get; set; }

        public Car(string model, string description, int price, CarID id, string image,bool isconfirmed,bool issold,string owner)
        {
            Model = model;
            Description = description;
            ID = id;
            Price = price;
            Image = image;
            IsConfirned = isconfirmed;
            IsSold = issold;
            Owner = owner;
        }

        public override bool Equals(object obj)
        {
            Car OtherCar = (Car)obj;
            return this.ID.Equals(OtherCar.ID);
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
            public override bool Equals(object obj)
            {
                var id = (CarID)obj;
                return this.IDValue == id.IDValue;
            }
        }
    }
}
