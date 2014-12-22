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
    class when_loading_industries
    {
        Common common = new Common();
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

            var industriesPage = new IndustriesPageObjects(driver, common.CONN_STRING + "#/industries");

            Assert.AreEqual("Industries", industriesPage.FindByIdWithAttribute("title", "title"));
        }

        [Test]
        public void should_have_one_or_more_industries()
        {
            var industriesPage = new IndustriesPageObjects(driver, common.CONN_STRING + "#/industries");

            Assert.GreaterOrEqual(1, industriesPage.GetIndustriesCount());
        }

    }
}
