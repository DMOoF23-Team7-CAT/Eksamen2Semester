using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.MVVM.Model.Base
{
    public class Pass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Pass()
        {
            
        }
        public Pass(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
