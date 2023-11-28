using KlatreKongen.MVVM.Model.Base;
using KlatreKongen.MVVM.Model.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace KlatreKongenTest1
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private CustomerRepository customerRepository;
        private Customer testCustomer;

        [TestInitialize]
        public void TestInitialize()
        {
            // Setup: Initialize the repository
            customerRepository = new CustomerRepository();

            // Adding a test customer for retrieval and update tests
            testCustomer = new Customer
            {
                Name = "Test Customer",
                DateOfBirth = new DateTime(1990, 1, 1),
                Phone = "123-456-7890",
                Email = "test.customer@example.com",
                Qualifications = "Test Qualifications",
                HasSignedDisclaimer = true
            };

            customerRepository.InsertCustomer(testCustomer);
        }

        [TestMethod]
        public void GetCustomers_ReturnsValidData()
        {
            // Act
            var customers = customerRepository.GetCustomers();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void GetCustomerById_ReturnsValidCustomer()
        {
            // Arrange: Retrieve the first customer for testing
            var retrievedCustomer = customerRepository.GetCustomers().LastOrDefault();

            // Act
            var retrievedByIdCustomer = customerRepository.GetCustomerById(retrievedCustomer.Id);

            // Assert
            Assert.IsNotNull(retrievedByIdCustomer);
            Assert.AreEqual(retrievedCustomer.Id, retrievedByIdCustomer.Id);
            // Add more assertions based on your specific requirements
        }

        [TestMethod]
        public void UpdateCustomer_UpdatesCustomerProperties()
        {
            // Arrange
            var customerToUpdate = customerRepository.GetCustomers().FirstOrDefault();
            customerToUpdate.Name = "Updated Name";
            customerToUpdate.Email = "updated.email@example.com";

            // Act
            customerRepository.UpdateCustomer(customerToUpdate);

            // Assert
            var updatedCustomer = customerRepository.GetCustomerById(customerToUpdate.Id);
            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(customerToUpdate.Name, updatedCustomer.Name);
            Assert.AreEqual(customerToUpdate.Email, updatedCustomer.Email);
            // Add more assertions based on your specific requirements
        }

        [TestMethod]
        public void DeleteCustomer_RemovesCustomer()
        {
            // Arrange: Retrieve the first customer for testing
            var customerToDelete = testCustomer;

            // Act
            customerRepository.DeleteCustomer(customerToDelete.Id);

            // Assert
            var deletedCustomer = customerRepository.GetCustomerById(customerToDelete.Id);
            Assert.IsNull(deletedCustomer);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Cleanup: Remove the test customer after tests are executed
            if (testCustomer != null)
            {
                customerRepository.DeleteCustomer(testCustomer.Id);
            }
        }
    }
}
