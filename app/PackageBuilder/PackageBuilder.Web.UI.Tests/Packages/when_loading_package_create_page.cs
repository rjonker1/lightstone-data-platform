using System;
using System.Threading;
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

            var createPackagePage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            Assert.AreEqual("Package Maintenance - Create", createPackagePage.FindByIdWithAttribute("title", "title"));
        }
        
        [Test]
        public void should_set_states_options_for_package()
        {

            var createPackagePage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            createPackagePage.selectDropDownByNum(1);

            var options = createPackagePage.ngDriver.FindElements(By.TagName("option"));

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

            var createPackagePage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            Assert.GreaterOrEqual(createPackagePage.GetAvailableDataProviders("provider in providers"), 1);
        }

        [Test]
        public void should_have_create_package_functionality()
        {

            var createPackagePage = new PackagesPageObjects(driver, common.CONN_STRING + "#/package-maintenance");

            driver.Navigate().GoToUrl(common.CONN_STRING + "#/packages");
            var countPackagesPre = createPackagePage.GetPackagesCount();

            driver.Navigate().GoToUrl(common.CONN_STRING + "#/package-maintenance");
            createPackagePage.CreatePackage("**ProtractorTestPackage");

            Thread.Sleep(500);

            driver.Navigate().GoToUrl(common.CONN_STRING + "#/packages");
            var countPackagesPost = createPackagePage.GetPackagesCount();

            Assert.Less(countPackagesPre, countPackagesPost);
        }

    }
}
