using NHibernate.Exceptions;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Persistence;

namespace Monitoring.Test.Helper.Mothers
{
    public class BusFactory
    {
        public static IBus NServiceRabbitMqBus()
        {
            var configuration = new BusConfiguration();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.DisableFeature<TimeoutManager>();
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("DataPlatform.Monitoring.Host");
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Lace.Shared.Monitoring.Messages.Commands"));
            //.DefiningEventsAs(
            //    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Events"))
            //.DefiningMessagesAs(
            //    m => m.Namespace != null && m.Namespace.StartsWith("Monitoring.Domain.Messages.Messages"));
            //configuration.EnableFeature<Sagas>();
            var bus = Bus.Create(configuration);
            return bus;
        }
    }
}
