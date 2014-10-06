using LightstoneApp.Domain.MainModule.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Domain.MainModule.Tests.Entities
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ExistInStock_Invoke_Test()
        {
            //Arrange
            var product = new Product
            {
                ProductId = 1,
                AmountInStock = 10
            };
            //act
            bool result = product.ExistStock();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExistInStock_LessThanZeroAmountInStockReturnFalse_Test()
        {
            //Arrange
            var product = new Product
            {
                ProductId = 1,
                AmountInStock = 0
            };
            //act
            bool result = product.ExistStock();

            //Assert
            Assert.IsFalse(result);
        }
    }
}