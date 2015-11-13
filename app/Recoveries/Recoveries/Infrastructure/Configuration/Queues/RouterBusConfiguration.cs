using Recoveries.Core;

namespace Recoveries.Infrastructure.Configuration.Queues
{
    public class RouterBusConfiguration
    {
        public static readonly string Host = AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost");
        public static readonly string QueueName = AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver", () => "Dataplatform.DataProvider.Recoveries.Reciever");
        public static readonly string ExchangeName = AppSettingsReader.GetString("dataplatform/queues/recoveries/exchange", () => "Dataplatform.DataProvider.Recoveries.Reciever");


    }
}
