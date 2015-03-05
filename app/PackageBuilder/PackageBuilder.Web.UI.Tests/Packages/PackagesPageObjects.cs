using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Protractor;

namespace PackageBuilder.Web.UI.Tests.Packages
{
    class PackagesPageObjects
    {

        public NgWebDriver ngDriver;
        private Common.Common common = new Common.Common();

        //ngDriver setup
        public PackagesPageObjects(IWebDriver driver, string url)
        {
            ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl(url);
        }

        public string FindByIdWithAttribute(string elementId, string attribute)
        {
            return ngDriver.FindElement(By.Id(elementId)).GetAttribute(attribute);
        }

        public int GetAvailableDataProviders(string query)
        {
            //Return number of dataProviders in ui.Grid
            return ngDriver.FindElements(NgBy.Repeater(query)).Count;
        }

        public void selectDropDownByNum(int optionNumber)
        {
            
            if (optionNumber >= 0)
            {
                var options = ngDriver.FindElements(By.TagName("option"));
                options[optionNumber].Click();
            }
            
        }

        public int GetPackagesCount()
        {

            //Return number of dataProviders in ui.Grid
            return ngDriver.FindElements(NgBy.Repeater("(rowRenderIndex, row) in rowContainer.renderedRows track by row.uid")).Count;
        }

        public void CreatePackage(string packageName)
        {

            ngDriver.FindElement(By.Id("package_name")).SendKeys(packageName);
            ngDriver.FindElement(By.Id("btn_save_package")).Click();
        }

    }
}
