using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using Cradle.KeepAlive.Service.Helpers;
using DataPlatform.Shared.Helpers.Extensions;
using Hangfire;
using Microsoft.Owin.Hosting;
using Nancy;

namespace Cradle.KeepAlive.Service
{
    public class KeepAliveService : IKeepAliveService
    {
        private BackgroundJobServer _server;
        Url url = ConfigurationManager.AppSettings["owinUrl"];

        public void Start()
        {
            WebApp.Start<StartupBootstrapper>(url);
            this.Info(() => "Started Keep-Alive Service");

            _server = new BackgroundJobServer();

            RecurringJob.AddOrUpdate<HealthCheck>("DataPlatform HealthCheck", x => x.PingDataPlatform(), ConfigurationManager.AppSettings["keepAliveCron"], TimeZoneInfo.Local);

            Console.WriteLine("\r");
            Console.WriteLine("Running on {0}", url);
            Console.WriteLine("\r\n");
            Console.WriteLine("*----------------------------------------------------------------------------*");
            Console.WriteLine("127.0.0.1 " + url + " <-- Required Hosts Entry!");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("\r");
            Console.WriteLine("Press Ctrl + c to exit");
        }

        public void Stop()
        {
            _server.Dispose();
            this.Info(() => "Keep-Alive Service Stopped");
        }
    }
}