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
        private DataTable _dataTable { get; set; }
        //private ObservableCollection<Customer> _customers { get; set; }

        public DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }

        public OverviewViewModel()
        {
            _customerRepository = new CustomerRepository();
            DataTable = _customerRepository.GetCustomersWithData();
        }

        public void RemoveCustomer(int customerid)
        {
            _customerRepository.DeleteCustomer(customerid);
        }

        //public ObservableCollection<Customer> Customers
        //{
        //    get { return _customers; }
        //    set { _customers = value; }
        //}


        //public void LoadDataGrid()
        //{
        //    _customerRepository.GetCustomersWithData();
        //}






    }
}
