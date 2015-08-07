using System;
using Recoveries.Core;
using Workflow.BuildingBlocks;

namespace Recoveries.Router.Configuration
{
    public class RecoveryReceiverQueueConfiguration : IDefineQueue
    {
        public RecoveryReceiverQueueConfiguration()
        {
            
        }

        public static RecoveryReceiverQueueConfiguration Receiver()
        {
            return new RecoveryReceiverQueueConfiguration();
        }

        public string ConnectionStringKey
        {
            get { return "recoveries/receiver/queue"; }
        }

        public string ErrorExchangeName
        {
            get { return AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver/error", () => "Dataplatform.DataProvider.Recoveries.Reciever.Errors"); }
        }

        public string ErrorQueueName
        {
            get { return AppSettingsReader.GetString("dataplatform/queues/recoveries/receiver/error", () => "Dataplatform.DataProvider.Recoveries.Reciever.Errors"); }
        }

        public string ExchangeType
        {
            get { return RabbitMQ.Client.ExchangeType.Fanout; }
        }
    }
}
