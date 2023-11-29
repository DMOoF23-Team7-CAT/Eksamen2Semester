using KlatreKongen.Model.Core;
using KlatreKongen.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlatreKongen.ViewModel
{
    internal class CustomerViewModel : ObservableObject
    {
        private readonly CustomerRepository _customerRepository;


        public CustomerViewModel()
        {
            _customerRepository = new CustomerRepository();
        }
        
    }
}
