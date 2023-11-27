using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.MVVM.Model.Base
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Qualifications { get; set; }
        public Membership? Membership { get; set; }
        public List<Entry>? Entries { get; set; }

        // Base constructor
        public Customer(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        // With Membership
        public Customer(string name, DateTime dateOfBirth,
            string phoneNumber, string email, string qualifications,
            Membership membership)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Qualifications = qualifications;
            Membership = membership;
        }

        // Without Membership
        public Customer(string name, DateTime dateOfBirth, string phone, string email, string qualifications)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phone;
            Email = email;
            Qualifications = qualifications;
        }
    }
}
