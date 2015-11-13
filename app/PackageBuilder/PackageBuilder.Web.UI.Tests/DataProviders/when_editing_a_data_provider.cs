using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace PackageBuilder.Web.UI.Tests.DataProviders
{
    class when_editing_a_data_provider
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
        public void should_navigate_to_relevant_data_provider()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-providers");
            var id = dataProvidersPage.GetDataProviderMetaAttribute("Lightstone", "dp_id");
            var version = dataProvidersPage.GetDataProviderMetaAttribute("Lightstone", "dp_version");

            dataProvidersPage.EditDataProvider("Lightstone");

            Assert.AreEqual(common.CONN_STRING + "#/data-provider-detail/"+ id + "/" + version, driver.Url);
        }

    }
}
