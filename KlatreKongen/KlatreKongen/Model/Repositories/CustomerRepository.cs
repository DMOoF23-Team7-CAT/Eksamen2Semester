using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KlatreKongen.MVVM.Model.Base;
using KlatreKongen.MVVM.Model.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace KlatreKongen.MVVM.Model.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public ObservableCollection<Customer> CustomerList;




        public CustomerRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = config.GetConnectionString("MyDBConnection");
        }

        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("spCustomersWithData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);

                                CustomerList = ConvertDataTableToCustomerList(dataTable);

                                return CustomerList;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving customers: {ex.Message}");
            }

        }

        private ObservableCollection<Customer> ConvertDataTableToCustomerList(DataTable dataTable)
        {
            CustomerList = new ObservableCollection<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                Customer customer = new Customer
                {
                    Id = Convert.ToInt32(row["CustomerId"]),
                    Name = row["CustomerName"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    Qualifications = row["Qualifications"].ToString(),
                    HasSignedDisclaimer = Convert.ToBoolean(row["HasSignedDisclaimer"]),
                };

                CustomerList.Add(customer);
            }

            return CustomerList;
        }

        public void DeleteCustomer(int customerId)
        {
            var customerToRemove = CustomerList.SingleOrDefault(x => x.Id == customerId);
            if (customerToRemove != null)
            {
                CustomerList.Remove(customerToRemove);
            }
            else
            {
                throw new Exception($"Customer with id: {customerId} could not be found and removed");
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            var customerToReturn = CustomerList.SingleOrDefault(customer => customer.Id == customerId);
            if (customerToReturn != null)
            {
                return customerToReturn;
            }
            else
            {
                throw new Exception($"Customer with id: {customerId} could not be found.");
            }
        }



        public void InsertCustomer(Customer customer)
        {
            CustomerList.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            // Don't know how to implement this
            throw new NotImplementedException();
        }
    }
}
