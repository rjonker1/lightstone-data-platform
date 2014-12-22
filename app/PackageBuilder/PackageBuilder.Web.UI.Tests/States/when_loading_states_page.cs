using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace PackageBuilder.Web.UI.Tests.States
{
    class when_loading_states_page
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

            var industriesPage = new StatesPageObjects(driver, common.CONN_STRING + "#/states");

            Assert.AreEqual("States", industriesPage.FindByIdWithAttribute("title", "title"));
        }

        [Test]
        public void should_have_three_or_more_states()
        {
            var industriesPage = new StatesPageObjects(driver, common.CONN_STRING + "#/states");

            Assert.GreaterOrEqual(3, industriesPage.GetIndustriesCount());
        }

    }
}
