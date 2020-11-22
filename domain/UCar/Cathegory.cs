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

        public class CathegoryID
        {
            public readonly int IDValue;
            public override string ToString()
            {
                return IDValue.ToString();
            }
        }
    }
}
