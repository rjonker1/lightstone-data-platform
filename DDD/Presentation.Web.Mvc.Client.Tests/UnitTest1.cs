using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protractor;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Tests
{
    [TestClass]
    public class HomeControllerTests : SeleniumTest
    {
        public HomeControllerTests() : base("ng.Presentation.Web.Mvc.Client", 2858)
        {
        }

        [Ignore]
        public void TestMethod1()
        {
            // Arrange
            var client = new WebClient();

            // Act
            string result = client.DownloadString(GetAbsoluteUrl("/sayhello"));

            // Assert
            StringAssert.Contains(result, "Hello from Nancy");
        }


        [Ignore]
        public void IndexChromeTest()
        {
            // Act
            ChromeDriver.Navigate().GoToUrl(GetAbsoluteUrl("/home/index"));
            ChromeDriver.FindElement(By.Id("btn")).Click();

            // Assert
            string text = ChromeDriver.FindElement(By.Id("msg")).Text;

            Assert.IsTrue(text == "hello!");
        }

        [Ignore]
        public void ShouldGreetUsingBinding()
        {
            // Act
            ChromeDriver.Navigate().GoToUrl(GetAbsoluteUrl("/home/index"));
            ChromeDriver.FindElement(NgBy.Input("sometext")).SendKeys("Wayne");


            // Assert

            const string expected = "Hello Wayne";
            string actural = ChromeDriver.FindElement(NgBy.Binding("{{ sometext }}")).Text;

            Assert.AreEqual(expected, actural);
        }
    }
}