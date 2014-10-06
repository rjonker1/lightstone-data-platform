using System;
using System.Collections.Generic;
using LightstoneApp.Application.MainModule.CustomersManagement;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.MainModule.Tests
{
    [TestClass]
    [DeploymentItem("LightstoneApp.Infrastructure.Data.MainModule.Mock.dll")]
    [DeploymentItem("LightstoneApp.Infrastructure.Data.MainModule.dll")]
    public class CustomerManagementServiceTests
    {
        [TestMethod]
        public void FindPagedCustomer_Invoke_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
            int pageIndex = 0;
            int pageCount = 1;

            //Act
            List<Customer> customers = customerService.FindPagedCustomers(pageIndex, pageCount);

            //Assert
            Assert.IsNotNull(customers);
            customers.ForEach(c => Assert.IsTrue(c.IsEnabled));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void FindPagedCustomers_Invoke_NullPageIndexThrowArgumentException_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            //Act
            List<Customer> customers = customerService.FindPagedCustomers(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void FindPagedCustomers_Invoke_NullPageCountThrowArgumentException_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            //Act
            List<Customer> customers = customerService.FindPagedCustomers(0, 0);
        }

        [TestMethod]
        public void FindCustomerByCode_Invoke_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
            string customerCode = "A0004";

            //Act
            Customer customer = customerService.FindCustomerByCode(customerCode);

            //Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.CustomerCode, customerCode);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ChangeCustomer_Invoke_NullItemThrowNewArgumentNullException_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            //Act
            customerService.ChangeCustomer(null);
        }

        [TestMethod]
        public void DeleteCustomer_Invoke_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            Customer randomCustomer = null;

            //Act
            randomCustomer = customerService.FindCustomerByCode("A0001");

            customerService.RemoveCustomer(randomCustomer);

            //Assert

            Customer removedCustomer = customerService.FindCustomerByCode("A0001");

            Assert.IsNull(removedCustomer);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void DeleteCustomer_Invoke_NullCustomerThrowArgumentNullException_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            Customer randomCustomer = null;

            //Act
            customerService.RemoveCustomer(randomCustomer);
        }

        [TestMethod]
        public void ChangeCustomer_Invoke_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
            string customerCode = "A0004";
            Customer customer = customerService.FindCustomerByCode(customerCode);

            //Act
            customer.ContactName = "Set new customer name";
            customerService.ChangeCustomer(customer);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void AddCustomer_Invoke_NullItemThrowArgumentNullException_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();

            customerService.AddCustomer(null);
        }

        [TestMethod]
        public void AddCustomer_Invoke_Test()
        {
            //Arrange
            var customerService = IoCFactory.Instance.CurrentContainer.Resolve<ICustomerManagementService>();
            string newCustomerCode = "C0001";
            var customer = new Customer
            {
                CustomerCode = newCustomerCode,
                ContactName = "Test",
                CountryId = 1,
                CompanyName = "Unit test",
                Address = new AddressInformation
                {
                    Address = "address2",
                    City = "Madrid",
                    Fax = "+340010001",
                    Telephone = "+340010001"
                },
                IsEnabled = true,
                CustomerPicture = new CustomerPicture {Photo = null}
            };

            //Act
            customerService.AddCustomer(customer);
            Customer inStorage = customerService.FindCustomerByCode(newCustomerCode);

            //Assert
            Assert.IsNotNull(inStorage);
        }
    }
}