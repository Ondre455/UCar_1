using System;
using System.Collections.Generic;
using System.Text;

namespace UCar
{
    public class Price
    {
        public int Rubles;
        public int Copeikas;
        public Price(int a, int b)
        {
            Rubles = a;
            while (b >= 100)
            {
                Rubles++;
                b -= 100;
            }
            Copeikas = b;
        }
        public override string ToString()
        {
            return Rubles.ToString() + "." + Copeikas.ToString();
        }
    }
}