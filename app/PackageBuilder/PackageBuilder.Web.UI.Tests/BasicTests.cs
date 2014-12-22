using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Protractor;

namespace PackageBuilder.Web.UI.Tests
{
    [TestFixture]
    public class BasicTests
    {

        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            //Using NuGet Package 'PhantomJS'
            //driver = new PhantomJSDriver(@"C:\Source\Repos\lightstone-data-platform\app\PackageBuilder.Web.UI.Tests\tools\phantomjs");

            //Using NuGet Package 'WebDriver.ChromeDriver.win32'
            driver = new ChromeDriver(@"C:\Source\Repos\lightstone-data-platform\app\PackageBuilder\PackageBuilder.Web.UI.Tests\tools\chrome");

            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(300));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void when_loading_industries()
        {
            IWebDriver ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("http://localhost:62500/#/industries"); // Basic test against Angular website
            //ngDriver.FindElement(NgBy.Input("yourName")).SendKeys("Allistaire");
            Assert.AreEqual("Industries", ngDriver.FindElement(By.Id("title")).GetAttribute("title"));
            //Assert.AreEqual(2, ngDriver.FindElements(NgBy.Repeater("(rowRenderIndex, row) in rowContainer.renderedRows track by row.uid)")).Count);
            ngDriver.Navigate().GoToUrl("http://angular.github.io/angular-phonecat/step-5/app/");
            Assert.AreEqual(20, ngDriver.FindElements(NgBy.Repeater("phone in phones")).Count);
        }

    }
}
