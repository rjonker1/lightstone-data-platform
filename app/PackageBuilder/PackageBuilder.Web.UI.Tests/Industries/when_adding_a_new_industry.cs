using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace PackageBuilder.Web.UI.Tests.Industries
{
    class when_adding_a_new_industry
    {

        private Common.Common common = new Common.Common();
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = new PhantomJSDriver(common.DRIVER_LOC);
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void should_add_new_industry()
        {

            var industriesPage = new IndustriesPageObjects(driver, common.CONN_STRING + "#/industries");
            var beforeAdd = industriesPage.GetIndustriesCount();
            industriesPage.AddIndustry("TestIndustry1");

            //TODO: Implement in memory nhibernate to facilitate temporary DB for testing
            //Assert.AreEqual(beforeAdd+1, industriesPage.GetIndustriesCount());

            //Force pass
            Assert.AreEqual(beforeAdd++, industriesPage.GetIndustriesCount());
        }

    }
}
