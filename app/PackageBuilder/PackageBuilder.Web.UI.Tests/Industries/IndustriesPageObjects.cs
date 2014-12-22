using OpenQA.Selenium;
using Protractor;

namespace PackageBuilder.Web.UI.Tests.Industries
{
    class IndustriesPageObjects
    {

        public NgWebDriver ngDriver;

        public IndustriesPageObjects(IWebDriver driver, string url)
        {
            ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl(url);
        }
        
        public string FindByIdWithAttribute(string elementId, string attribute)
        {
            return ngDriver.FindElement(By.Id(elementId)).GetAttribute(attribute);
        }
        
        public int GetIndustriesCount()
        {
            //Return number of industries in ui.Grid
            return ngDriver.FindElements(NgBy.Repeater("(rowRenderIndex, row) in rowContainer.renderedRows track by row.uid")).Count;
        }


    }
}
