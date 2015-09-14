using Shared.Configuration;
using Topshelf;

namespace Cradle.KeepAlive.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = new AppSettings();

            HostFactory.Run(x =>
            {
                x.RunAsPrompt();

                x.Service<IKeepAliveService>(s =>
                {
                    s.ConstructUsing(name => new KeepAliveService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsPrompt();

                x.SetDescription(appSettings.Service.Description);
                x.SetDisplayName(appSettings.Service.DisplayName);
                x.SetServiceName(appSettings.Service.Name);
            });
        }
    }
}
