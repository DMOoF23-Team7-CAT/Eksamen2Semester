using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.Model.Base
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasSignedDisclaimer { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Qualifications { get; set; }
        public Membership? Membership { get; set; }
        public List<Entry>? Entries { get; set; }

        // Base constructor
        public Customer()
        {
            
        }

        // With Name and DateOfBirth
        public Customer(string name, DateTime dateOfBirth, bool hasSignedDisclaimer)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            HasSignedDisclaimer = hasSignedDisclaimer;

        }


    }
}
