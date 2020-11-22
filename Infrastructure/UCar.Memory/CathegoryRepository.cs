using System;
using System.Collections.Generic;
using System.Text;

namespace UCar.Memory
{
    public class CathegoryRepository
    {
        private List<Cathegory> cathegories;
        public List<Cathegory> Cathegories
        {
            get
            {
                return cathegories;
            }
            set
            {
                cathegories.Add(new Cathegory("Внедорожник", new Cathegory.CathegoryID(1)));
                cathegories.Add(new Cathegory("Седан", new Cathegory.CathegoryID(2)));
            }
        }
    }
}
