using System;
using System.Timers;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using Shared.Configuration;
using Topshelf;
using Workflow.Reporting.Consumer.Installers;

namespace Workflow.Reporting.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var appSettings = new AppSettings();

            HostFactory.Run(x =>
            {
                x.Service<IReportingService>(s =>
                {
                    s.ConstructUsing(name => new ReportingService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStopped(rs => rs.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }

}
