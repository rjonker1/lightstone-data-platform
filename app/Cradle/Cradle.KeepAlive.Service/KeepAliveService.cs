using System;
using System.Collections.Generic;
using System.Configuration;
using Cradle.KeepAlive.Service.Helpers;
using Hangfire;
using Microsoft.Owin.Hosting;
using Nancy;
using RestSharp;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace Cradle.KeepAlive.Service
{
    public class KeepAliveService : IKeepAliveService
    {
        private BackgroundJobServer _server;
        private CheckEndpoint _checkEndpoint = new CheckEndpoint();
        private readonly Url _url = "http://+8081";

        public void Start()
        {
            WebApp.Start<StartupBootstrapper>(_url);

            _server = new BackgroundJobServer();

            var token = new Login().GetToken();
            var statusCheckList = new List<HttpStatusCode>();

            if (token != null)
            {
                // Check CIA
                var statusCIA = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/cia"], "ping", Method.GET);
                // Check UserManagement
                var statusUM = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/usermanagement"], "ping", Method.GET);
                // Check PackageBuilder
                var statusPB = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/packagebuilder"], "ping", Method.GET);
                // Check Billing
                var statusBill = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/billing"], "ping", Method.GET);
                // Check Reporting
                var statusReport = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/reporting"], "ping", Method.GET);
                // Check Monitoring
                var statusMonitor = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/monitoring"], "ping", Method.GET);
                // Check LIM
                var statusLIM = _checkEndpoint.Invoke(token, ConfigurationManager.AppSettings["endpoint/url/lim"], "ping", Method.GET);

                statusCheckList.AddRange(new List<HttpStatusCode>
                {
                    statusCIA,
                    statusUM,
                    statusPB,
                    statusBill, 
                    statusReport, 
                    statusMonitor,
                    statusLIM
                });
            }

            Console.WriteLine("Running on {0}", _url);
            Console.WriteLine("Press Ctrl + c to exit");
            Console.ReadLine();
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}