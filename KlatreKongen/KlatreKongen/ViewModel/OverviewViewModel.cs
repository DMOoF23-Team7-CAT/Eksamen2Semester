using KlatreKongen.Core;
using KlatreKongen.MVVM.Model.Base;
using KlatreKongen.MVVM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlatreKongen.MVVM.ViewModel
{
    class OverviewViewModel : ObservableObject
    {
        private readonly CustomerRepository _customerRepository;
        private ObservableCollection<Customer> _customer { get; set; }

        public ObservableCollection<Customer> Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public OverviewViewModel()
        {
            _customerRepository = new CustomerRepository();
            _customerRepository.GetCustomers();
            _customer = _customerRepository.CustomerList;            
        }

        
    }
}
