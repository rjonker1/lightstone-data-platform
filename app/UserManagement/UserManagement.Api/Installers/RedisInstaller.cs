using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Shared.Configuration;
using StackExchange.Redis;

namespace UserManagement.Api.Installers
{
    public class RedisInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var appSettings = new AppSettings();
            var options = ConfigurationOptions.Parse(appSettings.UserManagementApi.RedisServers);
            options.AbortOnConnectFail = false;
            container.Register(Component.For<ConnectionMultiplexer>().Instance(ConnectionMultiplexer.Connect(options)));
        }
    }
}
