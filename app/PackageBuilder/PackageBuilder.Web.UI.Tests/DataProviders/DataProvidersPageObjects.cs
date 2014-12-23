using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Protractor;

namespace PackageBuilder.Web.UI.Tests.DataProviders
{
    class DataProvidersPageObjects
    {

        public NgWebDriver ngDriver;

        //ngDriver setup
        public DataProvidersPageObjects(IWebDriver driver, string url)
        {
            ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl(url);
        }

        public string FindByIdWithAttribute(string elementId, string attribute)
        {
            return ngDriver.FindElement(By.Id(elementId)).GetAttribute(attribute);
        }

        public int GetDataProvidersCount()
        {
            //Return number of dataProviders in ui.Grid
            return ngDriver.FindElements(NgBy.Repeater("(rowRenderIndex, row) in rowContainer.renderedRows track by row.uid")).Count;
        }
        
        public int GetDataProviderFieldCount(string query)
        {
            //Return number of dataProviders in ui.Grid
            return ngDriver.FindElements(NgBy.Repeater(query)).Count;
        }

    }
}
