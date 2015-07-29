using Recoveries.Domain;

namespace Recoveries.ErrorQueues.Integrations
{
    public class IntegrationSenderConfiguration: IErrorQueueConfiguration
    {
        public IntegrationSenderConfiguration()
        {
            Options = new QueueOptions(
                AppSettingsReader.GetString("errors/dataplatform/integration/sender/queue", () => "DataPlatform.Integration.Sender"),
                AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost"),
                AppSettingsReader.GetString("rabbitmq/virtualhost", () => @"/"),
                AppSettingsReader.GetString("rabbitmq/username", () => "guest"),
                AppSettingsReader.GetString("rabbitmq/password", () => "guest"),
                AppSettingsReader.GetBool("errors/dataplatform/integration/sender/needHandshake", () => false),
                AppSettingsReader.GetInt("errors/dataplatform/integration/sender/maxNumberOfMessages", () => 1000),
                AppSettingsReader.GetString("errors/dataplatform/integration/sender/messageFilePath",
                    () => @"D:\DataplatformRecoveries\Integrations\Sender"),
                AppSettingsReader.GetString("errors/dataplatform/integration/sender/errorQueueName", () => "DataPlatform.Integration.Sender.Error"));
        }
        public IQueueOptions Options { get; private set; }
    }
}