using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace PackageBuilder.Web.UI.Tests.DataProviders
{
    class when_loading_data_provider_view_page
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

        //TODO: Need to implement a mock to edit specific dataprovider /{id}/{version}
        [Test]
        public void should_set_title()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-provider-view/59389746-3fe0-4578-a991-f0a6bbfbd536/1");

            Assert.AreEqual("Data Provider View : Request", dataProvidersPage.FindByIdWithAttribute("title", "title"));
        }

        [Test]
        public void should_set_field_table_title()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-provider-view/59389746-3fe0-4578-a991-f0a6bbfbd536/1");

            Assert.AreEqual("Data Provider View : Request - Data Fields", dataProvidersPage.FindByIdWithAttribute("field_table_title", "title"));
        }

        [Test]
        public void should_set_connection_details()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-provider-view/59389746-3fe0-4578-a991-f0a6bbfbd536/1");

            Assert.AreEqual("Data Provider View : Response", dataProvidersPage.FindByIdWithAttribute("connection_details", "title"));
        }

        [Test]
        public void should_have_fields()
        {

            var dataProvidersPage = new DataProvidersPageObjects(driver, common.CONN_STRING + "#/data-provider-view/59389746-3fe0-4578-a991-f0a6bbfbd536/1");

            Assert.GreaterOrEqual(dataProvidersPage.GetDataProviderFieldCount("dField in dataProv.dataFields"), 1);
        }

    }
}
