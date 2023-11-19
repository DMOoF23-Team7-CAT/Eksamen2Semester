using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.Model
{
    public class Membership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public double Discount { get; set; }
        public string Benefits { get; set; }
        public Customer Customer { get; set; }

        public Membership(DateTime startDate, DateTime endDate, Customer customer)
        {
            StartDate = startDate;
            EndDate = endDate;
            Customer = customer;
        }
    }
}
