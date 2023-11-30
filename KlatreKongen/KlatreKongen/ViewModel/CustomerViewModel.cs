using KlatreKongen.Model.Base;
using KlatreKongen.Model.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KlatreKongen.ViewModel
{
    internal class CustomerViewModel : ObservableObject
    {
        private Customer _customer;

        public ObservableCollection<Customer> Customers { get; set; }
        public CustomerViewModel()
        {
            Customers = new ObservableCollection<Customer>();
        }

        public RelayCommand AddCommand => new RelayCommand(_execute => AddCustomer(), _canExecute => { return true; });


        public Customer InsertCustomer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        private void AddCustomer()
        {
            Customers.Add(new Customer
            {
                Name = "New Name",
                DateOfBirth = new DateTime(2020, 12, 12),
                HasSignedDisclaimer = false,
                Phone = "20202020",
                Email = "hamder@gmail.com"
            });
        }
    }
}
