using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace LightstoneApp.Presentation.Web.Mvc.Client.Tests
{
    [TestClass]
    public abstract class SeleniumTest 
    {
        private string _applicationName;
        private Process _iisProcess;

        private int _iisPort;
 
        protected SeleniumTest(string applicationName, int iisPort) {
            _applicationName = applicationName;
            _iisPort = iisPort;
        }
 
 
        public FirefoxDriver FirefoxDriver { get; set; }
        public ChromeDriver ChromeDriver { get; set; }
        public InternetExplorerDriver InternetExplorerDriver { get; set; }
 
 
        [TestInitialize]
        public void TestInitialize() {
            // Start IISExpress
            StartIIS();
 
            // Start Selenium drivers
           // this.FirefoxDriver = new FirefoxDriver();
            this.ChromeDriver = new ChromeDriver("chromedriver_win32");
           // this.InternetExplorerDriver = new InternetExplorerDriver();
        }
 
 
        [TestCleanup]
        public void TestCleanup() {
            // Ensure IISExpress is stopped
            if (_iisProcess.HasExited == false) {
                _iisProcess.Kill();
            }
 
            // Stop all Selenium drivers
            //this.FirefoxDriver.Quit();
            this.ChromeDriver.Quit();
            //this.InternetExplorerDriver.Quit();
        }
 
 
 
        private void StartIIS() {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
 
            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, _iisPort);
            _iisProcess.Start();
        }
 
 
        protected virtual string GetApplicationPath(string applicationName) {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }
 
 
        public string GetAbsoluteUrl(string relativeUrl) {
            if (!relativeUrl.StartsWith("/")) {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}{1}", _iisPort, relativeUrl);
        }
 
 
    }
}