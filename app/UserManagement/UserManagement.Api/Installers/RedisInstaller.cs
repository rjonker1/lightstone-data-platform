using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using Shared.Configuration;
using Shared.Logging;
using StackExchange.Redis;

namespace UserManagement.Api.Installers
{
    public class RedisInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install RedisInstaller", SystemName.UserManagement);

            var appSettings = new AppSettings();
            var options = ConfigurationOptions.Parse(appSettings.UserManagementApi.RedisServers);
            options.AbortOnConnectFail = false;
            container.Register(Component.For<ConnectionMultiplexer>().Instance(ConnectionMultiplexer.Connect(options)));

            this.Info(() => "Successfully installed RedisInstaller", SystemName.UserManagement);
        }
    }
}
