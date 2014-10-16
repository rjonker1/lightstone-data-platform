using System;
using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.MainModule.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Domain.MainModule.Tests.Entities
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void GetNumberOfItems_Test()
        {
            //Arrange
            var order = new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                CustomerId = 1,
                OrderDetails = new TrackableCollection<OrderDetail>
                {
                    new OrderDetail {OrderDetailsId = 1, Discount = 0, ProductId = 1, Amount = 3},
                    new OrderDetail {OrderDetailsId = 1, Discount = 0, ProductId = 2, Amount = 12},
                }
            };

            //Act
            int numberOfItems = order.GetNumberOfItems();

            //Asert
            Assert.AreEqual(15, numberOfItems);
        }
    }
}