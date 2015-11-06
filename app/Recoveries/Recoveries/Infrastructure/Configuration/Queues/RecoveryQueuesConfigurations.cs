using Recoveries.Core;

namespace Recoveries.Infrastructure.Configuration.Queues
{
    public class RecoveryReceiverQueueConfiguration : IDefineRabbitQueue
    {
        public RecoveryReceiverQueueConfiguration()
        {
            
        }

        public static RecoveryReceiverQueueConfiguration Receiver()
        {
            return new RecoveryReceiverQueueConfiguration();
        }

        public string Host
        {
            get { return RouterBusConfiguration.Host; }
        }

        public string ExchangeName
        {
            get { return RouterBusConfiguration.ExchangeName; }
        }

        public string ErrorExchangeName
        {
            get { return AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver/error", () => "Dataplatform.DataProvider.Recoveries.Reciever.Errors"); }
        }

        public string ErrorQueueName
        {
            get { return AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver/error", () => "Dataplatform.DataProvider.Recoveries.Reciever.Errors"); }
        }


        public string QueueName
        {
            get { return RouterBusConfiguration.QueueName; }
        }
    }
}
