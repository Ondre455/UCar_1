using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCar
{
    /// <summary>
    /// Класс Автомобиль
    /// обозначакт представление машины в системе
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string Image { get; }
        /// <summary>
        /// айди машины
        /// </summary>
        public CarID ID { get; }
        /// <summary>
        /// Модель машины
        /// </summary>
        [Display(Name="Модель")]
        public string Model { get; }
        /// <summary>
        /// описание машины
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; }
        /// <summary>
        /// цена машины
        /// </summary>
        [Display(Name = "Цена ")]
        public int Price { get; }
        /// <summary>
        /// до проверки машины false иначе true
        /// </summary>
        public bool IsConfirned { get; set; }
        /// <summary>
        /// до продажи машины false иначе true
        /// </summary>
        public bool IsSold { get; set; }
        /// <summary>
        /// Владелец автомобиля
        /// определяет, кому был продан автомобиль,
        /// или у кого он был куплен
        /// </summary>
        [Display(Name ="Владелец")]
        public string Owner { get; set; }

        /// <summary>
        /// создает машину с заданными параметрами
        /// </summary>
        /// <param name="model"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="id"></param>
        /// <param name="image"></param>
        /// <param name="isconfirmed"></param>
        /// <param name="issold"></param>
        /// <param name="owner"></param>
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

        /// <summary>
        /// другой способ создать машину
        /// </summary>
        /// <param name="str"></param>
        public Car(string str)
        {
            var CStr = str.Split('_');
            Model = CStr[0];
            Description = CStr[1];
            ID = new CarID(int.Parse(CStr[2]));
            Price = int.Parse(CStr[3]);
            Image = CStr[4];
            IsConfirned = bool.Parse(CStr[5]);
            IsSold = bool.Parse(CStr[6]);
            Owner = CStr[7];
        }
        
        /// <summary>
        /// создает представление машины в виде строки
        /// </summary>
        /// <returns>Строка, представляющая машину</returns>
        public override string ToString()
        {
            return Model + "_" + Description + "_" + ID.ToString() + "_" + Price.ToString() + "_" + Image + "_" + IsConfirned.ToString() + "_" + IsSold.ToString() + "_" + Owner;
        }

        /// <summary>
        /// класс айди, 
        /// создан для расширения проекта, когда не только машины будут иметь его
        /// </summary>
        public class CarID
        {
            /// <summary>
            /// значение айди
            /// </summary>
            public readonly int IDValue;

            /// <summary>
            /// конструктор для айди
            /// </summary>
            /// <param name="id"></param>
            public CarID(int id)
            {
                IDValue = id;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Значение айди как строку</returns>
            public override string ToString()
            {
                return IDValue.ToString();
            }

            /// <summary>
            /// Сравнивает айди 2 машин
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                var id = (CarID)obj;
                return this.IDValue == id.IDValue;
            }
        }
    }
}
