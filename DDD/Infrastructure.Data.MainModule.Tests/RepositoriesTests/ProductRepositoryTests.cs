using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Domain.MainModule.Products;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.MainModule.Repositories;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.MainModule.Tests.RepositoriesTests
{
    [TestClass]
    public class ProductRepositoryTests
        : RepositoryTestsBase<Product>
    {
        private int productId = 1;

        public override Expression<Func<Product, bool>> FilterExpression
        {
            get { return p => p.ProductId == productId; }
        }

        public override Expression<Func<Product, int>> OrderByExpression
        {
            get { return p => p.ProductId; }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void FindProductByProductInformation_NullSpecThrowNewArgumentNullException_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            var repository = new ProductRepository(context, traceManager);

            //Act
            repository.GetBySpec(null);
        }

        [TestMethod]
        public void FindProductByProductInformation_Invoke_Test()
        {
            //Arrange
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();

            var repository = new ProductRepository(context, traceManager);


            string publisher = "Krasis Press";
            string description = null;
            var specification = new ProductInformationSpecification(publisher, description);

            //Act
            IEnumerable<Product> result = repository.GetBySpec(specification);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
    }
}