using System;
using System.Linq.Expressions;
using LightstoneApp.Domain.MainModule.Customers;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.MainModule.Repositories;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.MainModule.Tests.RepositoriesTests
{
    [TestClass]
    public class CustomerRepositoryTests
        : RepositoryTestsBase<Customer>
    {
        public override Expression<Func<Customer, bool>> FilterExpression
        {
            get { return c => c.CustomerCode == "A0004"; }
        }

        public override Expression<Func<Customer, int>> OrderByExpression
        {
            get { return c => c.CustomerId; }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindCustomer_Invoke_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            ICustomerRepository repository = new CustomerRepository(context, traceManager);

            //Act
            repository.FindCustomer(null);
        }

        [TestMethod]
        public void FindCustomer_Invoke_Test()
        {
            //Arrange 
            string customerCode = "A0004";
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            ICustomerRepository repository = new CustomerRepository(context, traceManager);

            var spec = new CustomerCodeSpecification(customerCode);

            //Act
            Customer customer = repository.FindCustomer(spec);

            //Assert
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.CustomerPicture);
        }
    }
}