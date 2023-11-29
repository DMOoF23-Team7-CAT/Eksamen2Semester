using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlatreKongen.Model.Base
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CheckinTime { get; set; }
        public double Price;
        public List<Pass>? Passes { get; set; }

        // Base constructor
        public Entry()
        {
        }

        public Entry(DateTime checkinTime, double price)
        {
            CheckinTime = checkinTime;
            Price = price;
        }

    }
}
