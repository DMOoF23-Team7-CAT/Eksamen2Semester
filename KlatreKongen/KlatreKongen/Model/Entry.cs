using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KlatreKongen.Model
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CheckinTime { get; set; }
        public double Price;
        public List<Pass> Passes { get; set; }
        //public List<Equipment> Equipment

        public Entry(DateTime checkinTime, double price)
        {
            CheckinTime = checkinTime;
            Price = price;
        }
    }
}
