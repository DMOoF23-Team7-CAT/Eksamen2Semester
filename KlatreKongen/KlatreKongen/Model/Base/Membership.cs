using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.MVVM.Model.Base
{
    public class Membership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public double? Discount { get; set; }
        public string? Benefits { get; set; }
        public int CustomerId { get; set; }


        // Base Constructor
        public Membership(DateTime startDate, DateTime endDate, int customerId)
        {
            StartDate = startDate;
            EndDate = endDate;
            CustomerId = customerId;
            Active = true;

        }

    }
}
