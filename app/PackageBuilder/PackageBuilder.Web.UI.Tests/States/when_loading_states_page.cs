using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using PackageBuilder.Web.UI.Tests.Common;
using Protractor;

namespace PackageBuilder.Web.UI.Tests.States
{
    internal class when_loading_states_page
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

            var industriesPage = new StatesPageObjects(driver, common.CONN_STRING + "#/states");

            Assert.AreEqual("States", industriesPage.FindByIdWithAttribute("title", "title"));
        }

        [Test]
        public void should_have_three_or_more_states()
        {
            var industriesPage = new StatesPageObjects(driver, common.CONN_STRING + "#/states");

            Assert.GreaterOrEqual(3, industriesPage.GetIndustriesCount());
        }

//        [Test]
//        public void should_have_three_or_more_states2()
//        {

//            NgMockE2EModule mockModule = new NgMockE2EModule(@"
//$httpBackend.whenGET('../../phones/phones.json').respond(
//[
//    {
//        age: 12, 
//        carrier: 'AT&amp;T', 
//        id: 'motorola-bravo-with-motoblur', 
//        imageUrl: 'img/phones/motorola-bravo-with-motoblur.0.jpg', 
//        name: 'MOTOROLA BRAVO\u2122 with MOTOBLUR\u2122', 
//        snippet: 'An experience to cheer about.'
//    }, 
//    {
//        age: 13, 
//        carrier: 'T-Mobile', 
//        id: 'motorola-defy-with-motoblur', 
//        imageUrl: 'img/phones/motorola-defy-with-motoblur.0.jpg', 
//        name: 'Motorola DEFY\u2122 with MOTOBLUR\u2122', 
//        snippet: 'Are you ready for everything life throws your way?'
//    }, 
//]
//);
//");

//            //IWebDriver ngDriver = new NgWebDriver(driver, mockModule);
//            //ngDriver.Navigate().GoToUrl("http://localhost:62500/#/states");

//            //Assert.AreEqual(2, ngDriver.FindElements(NgBy.Repeater("phone in phones")).Count);

//            IWebDriver ngDriver = new NgWebDriver(driver, mockModule);
//            ngDriver.Navigate().GoToUrl("http://localhost:62500/#/states");
//            Assert.AreEqual(2, ngDriver.FindElements(NgBy.Repeater("phone in phones")).Count);

//        }
    }
}