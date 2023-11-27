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

            CustomerList = new ObservableCollection<Customer>();
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
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customerId", SqlDbType.Int) { Value = customerId });

                    cmd.ExecuteNonQuery();
                }

                var customerToRemove = CustomerList.SingleOrDefault(x => x.Id == customerId);
                if (customerToRemove != null)
                {
                    CustomerList.Remove(customerToRemove);
                }
                
            }
            catch (Exception ex)
            { 
                throw new Exception($"Customer with id: {customerId} could not be found and removed \n\n{ex.Message}");
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spCustomerByIdWithData", con);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                Name = reader.GetString(reader.GetOrdinal("CustomerName")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Qualifications = reader.GetString(reader.GetOrdinal("Qualifications")),
                                HasSignedDisclaimer = reader.GetBoolean(reader.GetOrdinal("HasSignedDisclaimer"))
                            };
                        }
                    }
                }

                return customer;

            }
            catch (Exception ex)
            {
                throw new Exception($"Customer with id: {customerId} could not be found.\n\n{ex.Message}");
            }
        }



        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = customer.Name });
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = customer.DateOfBirth });
                cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = customer.Phone });
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = customer.Email });
                cmd.Parameters.Add(new SqlParameter("@Qualifications", SqlDbType.NVarChar, 255) { Value = customer.Qualifications });
                cmd.Parameters.Add(new SqlParameter("@HasSignedDisclaimer", SqlDbType.Bit) { Value = customer.HasSignedDisclaimer });

                cmd.ExecuteNonQuery();

            }

            CustomerList.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                    cmd.Parameters.AddWithValue("@CustomerId", customer.Id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = customer.Name });
                    cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = customer.DateOfBirth });
                    cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = customer.Phone });
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = customer.Email });
                    cmd.Parameters.Add(new SqlParameter("@Qualifications", SqlDbType.NVarChar, 255) { Value = customer.Qualifications });
                    cmd.Parameters.Add(new SqlParameter("@HasSignedDisclaimer", SqlDbType.Bit) { Value = customer.HasSignedDisclaimer });

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error while updating Customer with id: {customer.Id}\n\n{ex.Message}");
            }
        }
    }
}
