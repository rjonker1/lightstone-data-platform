using Recoveries.Domain;

namespace Recoveries.ErrorQueues.Integrations
{
    public class IntegrationReceiverConfiguration: IErrorQueueConfiguration
    {
        public IntegrationReceiverConfiguration()
        {
            Options = new QueueOptions(
                AppSettingsReader.GetString("errors/dataplatform/integration/receiver/queue", () => "DataPlatform.Integration.Receiver"),
                AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost"),
                AppSettingsReader.GetString("rabbitmq/virtualhost", () => @"/"),
                AppSettingsReader.GetString("rabbitmq/username", () => "guest"),
                AppSettingsReader.GetString("rabbitmq/password", () => "guest"),
                AppSettingsReader.GetBool("errors/dataplatform/integration/receiver/needHandshake", () => false),
                AppSettingsReader.GetInt("errors/dataplatform/integration/receiver/maxNumberOfMessages", () => 1000),
                AppSettingsReader.GetString("errors/dataplatform/integration/receiver/messageFilePath",
                    () => @"D:\DataplatformRecoveries\Integrations\Receiver"),
                AppSettingsReader.GetString("errors/dataplatform/integration/receiver/errorQueueName", () => "DataPlatform.Integration.Receiver.Error"));
        }
        public IQueueOptions Options { get; private set; }
    }
}