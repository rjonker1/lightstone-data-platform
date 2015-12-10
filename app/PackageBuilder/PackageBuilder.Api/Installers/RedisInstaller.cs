using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;
using StackExchange.Redis;

namespace PackageBuilder.Api.Installers
{
    public class RedisInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ConnectionMultiplexer>().Instance(ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString },
                ConnectRetry = 3,
                AbortOnConnectFail = false
            })));
            var connectionMultiplexer = container.Resolve<ConnectionMultiplexer>();
            connectionMultiplexer.ConnectionFailed += (sender, args) => this.Error(() => "Redis: ConnectionFailed", args.Exception);
            connectionMultiplexer.InternalError += (sender, args) => this.Error(() => "Redis: InternalError ", args.Exception);
            connectionMultiplexer.ErrorMessage += (sender, args) => this.Error(() => "Redis: ErrorMessage {0}".FormatWith(args.Message));
            //connectionMultiplexer.RegisterProfiler(new RedisProfiler(container.Resolve<INancyContextWrapper>()));
            container.Register(Component.For<IDatabase>().UsingFactoryMethod(x => connectionMultiplexer.GetDatabase()).LifeStyle.HybridPerWebRequestTransient());
        }
    }
}