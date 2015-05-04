using Shared.Configuration;
using Topshelf;

namespace Workflow.Reporting.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = new AppSettings();

            HostFactory.Run(x =>
            {
                x.Service<IReportingService>(s =>
                {
                    s.ConstructUsing(name => new ReportingService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStarted(rs => rs.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}
