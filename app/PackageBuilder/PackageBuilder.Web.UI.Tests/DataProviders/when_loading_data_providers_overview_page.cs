using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace PackageBuilder.Web.UI.Tests.DataProviders
{
    //dataProviders.html
    class when_loading_data_providers_overview_page
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
        public void should_set_title()
        {
            
            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-providers");

            Assert.AreEqual("Data Providers", dataProvidersPage.FindByIdWithAttribute("title", "title"));
        }
        
        [Test]
        public void should_have_minimum_5_dataProviders_specified()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-providers");

            Assert.GreaterOrEqual(5, dataProvidersPage.GetDataProvidersCount());
        }

    }
}
