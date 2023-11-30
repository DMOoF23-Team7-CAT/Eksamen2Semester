using KlatreKongen.Model.Base;
using KlatreKongen.Model.Core;
using KlatreKongen.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.ViewModel
{
    class StartViewModel : ObservableObject
    {
        private readonly CustomerRepository _customerRepository;
        private DataTable customerMembershipTable;
        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set 
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }


        public DataTable CustomerMembershipTable
        {
            get { return customerMembershipTable; }
            set 
            {
                customerMembershipTable = value;
                OnPropertyChanged(nameof(CustomerMembershipTable));
            }
        }


        public StartViewModel()
        {
            _customerRepository = new CustomerRepository();
            CustomerMembershipTable = _customerRepository.GetCustomerMemberships();
        }

        public Customer GetById(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            return customer;
        }
        public void CheckCustomerIn()
        {

        }
    }
}
