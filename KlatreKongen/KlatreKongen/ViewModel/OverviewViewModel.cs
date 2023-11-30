using KlatreKongen.Model.Core;
using KlatreKongen.Model.Base;
using KlatreKongen.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlatreKongen.ViewModel
{
    class OverviewViewModel : ObservableObject
    {
        private readonly CustomerRepository _customerRepository;
        private ObservableCollection<Customer> _customer { get; set; }
        private DataTable _dataTable { get; set; }

        public DataTable DataTable
        {

            get { return _dataTable; }
            set { _dataTable = value; }


        }

        public ObservableCollection<Customer> Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public OverviewViewModel()
        {
            _customerRepository = new CustomerRepository();
            _dataTable = _customerRepository.GetCustomersWithData();
            //_customer = _customerRepository.CustomerList;
        }

        public void RemoveCustomer(int customerid)
        {
            _customerRepository.DeleteCustomer(customerid);
        }



    }
}
