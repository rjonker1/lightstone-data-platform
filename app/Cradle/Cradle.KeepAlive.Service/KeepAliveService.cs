using System;
using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cradle.KeepAlive.Service.Domain;
using Cradle.KeepAlive.Service.Helpers.Installers;
using DataPlatform.Shared.Helpers.Extensions;
using Hangfire;
using Hangfire.Windsor;
using Microsoft.Owin.Hosting;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;

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

            var container = new WindsorContainer();
            container.Register(Component.For<IApiClient>().ImplementedBy<ApiClient>());
            container.Register(Component.For<HealthCheck>());
            container.Register(Component.For<LoginCheck>());
            container.Register(Component.For<PackageCheck>());

            JobActivator.Current = new WindsorJobActivator(container.Kernel);

            RecurringJob.AddOrUpdate<HealthCheck>("DataPlatform HealthCheck", x => x.PingDataPlatform(), ConfigurationManager.AppSettings["pollingCron"], TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<LoginCheck>("DataPlatform Mobile LoginCheck", x => x.MobileLogin(), ConfigurationManager.AppSettings["pollingCron"], TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<LoginCheck>("DataPlatform API LoginCheck", x => x.ApiLogin(), ConfigurationManager.AppSettings["pollingCron"], TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<PackageCheck>("DataPlatform API PackageCheck", x => x.InvokePackage(), ConfigurationManager.AppSettings["pollingCron"], TimeZoneInfo.Local);

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