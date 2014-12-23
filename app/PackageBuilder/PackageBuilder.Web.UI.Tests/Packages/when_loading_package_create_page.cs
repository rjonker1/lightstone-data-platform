using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Protractor;

namespace PackageBuilder.Web.UI.Tests.Packages
{
    class when_loading_package_create_page
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

            var dataProvidersPage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            Assert.AreEqual("Package Maintenance - Create", dataProvidersPage.FindByIdWithAttribute("title", "title"));
        }
        
        [Test]
        public void should_set_states_options_for_package()
        {

            var dataProvidersPage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            dataProvidersPage.selectDropDownByNum(1);

            var options = dataProvidersPage.ngDriver.FindElements(By.TagName("option"));

            foreach (NgWebElement opt in options)
            {
                if (opt.Selected)
                {
                    Assert.AreEqual("Expired", opt.Text);
                }
            }
        }
        
        [Test]
        public void should_have_dataproviders_available()
        {

            var dataProvidersPage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            Assert.GreaterOrEqual(dataProvidersPage.GetAvailableDataProviders("provider in providers"), 1);
        }

    }
}
