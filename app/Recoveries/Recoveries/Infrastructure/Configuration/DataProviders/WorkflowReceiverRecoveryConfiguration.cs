using System.Runtime.Serialization;
using Recoveries.Core;

namespace Recoveries.Infrastructure.Configuration.DataProviders
{
    [DataContract]
    public class WorkflowReceiverRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowReceiverRecoveryConfiguration()
        {
            Options = new QueueOptions(
                AppSettingsReader.GetString("errors/dataplatform/workflow/receiver/queue", () => "DataPlatform.DataProvider.Receiver"),
                AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost"),
                AppSettingsReader.GetString("rabbitmq/virtualhost", () => @"/"),
                AppSettingsReader.GetString("rabbitmq/username", () => "guest"),
                AppSettingsReader.GetString("rabbitmq/password", () => "guest"),
                AppSettingsReader.GetBool("errors/dataplatform/workflow/receiver/needHandshake", () => false),
                AppSettingsReader.GetInt("errors/dataplatform/workflow/receiver/maxNumberOfMessages", () => 1000),
                AppSettingsReader.GetString("errors/dataplatform/workflow/receiver/messageFilePath",
                    () => @"D:\DataplatformRecoveries\DataProviders\Receiver"),
                AppSettingsReader.GetString("errors/dataplatform/workflow/receiver/errorQueueName", () => "DataPlatform.DataProvider.Receiver.Error"));
        }

        [DataMember]
        public IQueueOptions Options { get; private set; }
    }
}