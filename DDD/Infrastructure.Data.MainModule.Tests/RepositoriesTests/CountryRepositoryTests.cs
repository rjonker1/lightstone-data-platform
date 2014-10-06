using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Domain.MainModule.Countries;
using LightstoneApp.Domain.MainModule.Customers;
using LightstoneApp.Domain.MainModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.Logging;
using LightstoneApp.Infrastructure.Data.MainModule.Repositories;
using LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.MainModule.Tests.RepositoriesTests
{
    [TestClass]
    public class CountryRepositoryTests
        : RepositoryTestsBase<Country>
    {
        private int countryId = 1;

        public override Expression<Func<Country, bool>> FilterExpression
        {
            get { return c => c.CountryId == countryId; }
        }

        public override Expression<Func<Country, int>> OrderByExpression
        {
            get { return c => c.CountryId; }
        }

        [TestMethod]
        public void FindCountriesByName_Invoke_Test()
        {
            //Arrange 
            IMainModuleUnitOfWork context = GetUnitOfWork();
            ITraceManager traceManager = GetTraceManager();
            ICountryRepository repository = new CountryRepository(context, traceManager);

            string name = "Germany";
            var spec = new CountryNameSpecification(name);

            //Act
            IEnumerable<Country> countries = repository.GetBySpec(spec);

            //Assert
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Count() > 0);
        }
    }
}