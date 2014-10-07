using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protractor;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Tests
{
   

    [TestClass]
    public class HomeControllerTests : SeleniumTest
    {

        public HomeControllerTests() : base("ng.Presentation.Web.Mvc.Client", 2858) { }

        [Ignore]
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var client = new WebClient();

            // Act
            var result = client.DownloadString(GetAbsoluteUrl("/sayhello"));

            // Assert
            StringAssert.Contains(result, "Hello from Nancy");
        }


        [Ignore]
        [TestMethod]
        public void IndexChromeTest()
        {
            // Act
            this.ChromeDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/home/index"));
            this.ChromeDriver.FindElement(By.Id("btn")).Click();

            // Assert
            var text = this.ChromeDriver.FindElement(By.Id("msg")).Text;

            Assert.IsTrue(text == "hello!");
        }

        [Ignore]
        [TestMethod]
        public void ShouldGreetUsingBinding()
        {
            // Act
            this.ChromeDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/home/index"));
            this.ChromeDriver.FindElement(NgBy.Input("sometext")).SendKeys("Wayne");


            // Assert

            const string expected = "Hello Wayne";
            var actural = this.ChromeDriver.FindElement(NgBy.Binding("{{ sometext }}")).Text;

            Assert.AreEqual(expected, actural);


        }


    }
}
