
using NServiceBus.Features;
using NServiceBus.Persistence;

namespace Monitoring.DistributedService.Consumer
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.DisableFeature<TimeoutManager>();
            configuration.UseTransport<RabbitMQTransport>();
          
            configuration.Conventions()
                .DefiningCommandsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Commands"))
                .DefiningEventsAs(
                    c => c.Namespace != null && c.Namespace.StartsWith("Monitoring.Domain.Messages.Events"))
                .DefiningMessagesAs(
                    m =>
                        m.Namespace != null &&
                        m.Namespace.StartsWith("Monitoring.Domain.Messages.Messages"));

            
            //configuration.EndpointName("Monitoring.DistributedService.Consumer");
            configuration.EnableFeature<Sagas>();
            configuration.UsePersistence<NHibernatePersistence>().For(Storage.Sagas, Storage.Subscriptions);
            
        }
    }
}
