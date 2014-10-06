using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Domain.MainModule.Orders;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.MainModule.Repositories;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.MainModule.Tests.RepositoriesTests
{
    /// <summary>
    ///     Summary description for OrderRepositoryTest
    /// </summary>
    [TestClass]
    public class OrderRepositoryTests
        : RepositoryTestsBase<Order>
    {
        private string customerCode = "A0002";
        private int orderId = 1;

        public override Expression<Func<Order, bool>> FilterExpression
        {
            get { return o => o.OrderId == orderId; }
        }

        public override Expression<Func<Order, int>> OrderByExpression
        {
            get { return o => o.OrderId; }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindOrdersByDate_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);

            //Act
            repository.GetBySpec(null);
        }

        [TestMethod]
        public void FindOrdersByDate_NullDateSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);
            var ordersSpec = new OrderDateSpecification(null, null);

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(ordersSpec);

            //Asser
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() > 0);
        }

        [TestMethod]
        public void FindOrdersByDate_MaxMinDateSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);
            var ordersSpec = new OrderDateSpecification(DateTime.MinValue, DateTime.MaxValue);
            //Act
            IEnumerable<Order> orders = repository.GetBySpec(ordersSpec);

            //Asser
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() > 0);
        }

        [TestMethod]
        public void FindOrdersByDate_NullFromDateSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);

            var ordersSpec = new OrderDateSpecification(null, DateTime.MaxValue);

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(ordersSpec);

            //Asser
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() > 0);
        }

        [TestMethod]
        public void FindOrdersByDate_NullToDateSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);
            var ordersSpec = new OrderDateSpecification(DateTime.MinValue, null);
            //Act
            IEnumerable<Order> orders = repository.GetBySpec(ordersSpec);

            //Asser
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindOrdersByShippingInfo_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            IOrderRepository repository = new OrderRepository(context, traceManager);


            //Act
            repository.GetBySpec(null);
        }

        [TestMethod]
        public void FindOrdersByShippingInfo_NullDataInShippSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);
            var spec = new OrderShippingSpecification(null, null, null, null);

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() > 0);
        }

        [TestMethod]
        public void FindOrdersByShippingInfo_FullDataInShippSpec_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            IOrderRepository repository = new OrderRepository(context, traceManager);
            string title = "Book EF buy";
            string address = "Sebastian el Cano";
            string city = "Madrid";
            string zipCode = "28081";
            var spec = new OrderShippingSpecification(title, address, city, zipCode);

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count() >= 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindOrdersByCustomerCode_NullCodeThrowNewArgumentNullException_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            IOrderRepository repository = new OrderRepository(context, traceManager);

            //Act
            repository.FindOrdersByCustomerCode(null);
        }

        [TestMethod]
        public void FindOrdersByCustomerCode_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            IOrderRepository repository = new OrderRepository(context, traceManager);

            //Act
            IEnumerable<Order> orders = repository.FindOrdersByCustomerCode(customerCode);

            //Assert
            Assert.IsNotNull(orders);
        }

        [TestMethod]
        public void FindOrdersByCustomerDateRangeSpecification_Invoke_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            IOrderRepository repository = new OrderRepository(context, traceManager);

            var spec = new OrderFromCustomerDateRangeSpecification(1, new DateTime(2008, 12, 1),
                new DateTime(2009, 2, 1));

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(orders);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindOrdersByCustomerDateRangeSpecification_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            IOrderRepository repository = new OrderRepository(context, traceManager);

            //Act
            IEnumerable<Order> orders = repository.GetBySpec(null);
        }
    }
}