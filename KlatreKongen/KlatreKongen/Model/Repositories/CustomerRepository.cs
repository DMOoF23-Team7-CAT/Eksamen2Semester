using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlatreKongen.MVVM.Model.Base;
using KlatreKongen.MVVM.Model.Interfaces;

namespace KlatreKongen.MVVM.Model.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;

        public void DeleteCustomer(int customerId)
        {
            var customerToRemove = _customerList.SingleOrDefault(x => x.Id == customerId);
            if (customerToRemove != null)
            {
                _customerList.Remove(customerToRemove);
            }
            else
            {
                throw new Exception($"Customer with id: {customerId} could not be found and removed");
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            var customerToReturn = _customerList.SingleOrDefault(customer => customer.Id == customerId);
            if (customerToReturn != null)
            {
                return customerToReturn;
            }
            else
            {
                throw new Exception($"Customer with id: {customerId} could not be found.");
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerList;
        }

        public void InsertCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            // Don't know how to implement this
            throw new NotImplementedException();
        }
    }
}
