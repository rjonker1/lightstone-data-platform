using Recoveries.Domain;

namespace Recoveries.ErrorQueues.DataProviders
{
    public sealed class WorkflowSenderRecoveryConfiguration : IErrorQueueConfiguration
    {
        public WorkflowSenderRecoveryConfiguration()
        {
            Options = new QueueOptions(
                AppSettingsReader.GetString("errors/dataplatform/workflow/sender/queue", () => "DataPlatform.DataProvider.Sender"),
                AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost"),
                AppSettingsReader.GetString("rabbitmq/virtualhost", () => @"/"),
                AppSettingsReader.GetString("rabbitmq/username", () => "guest"),
                AppSettingsReader.GetString("rabbitmq/password", () => "guest"),
                AppSettingsReader.GetBool("errors/dataplatform/workflow/sender/needHandshake", () => false),
                AppSettingsReader.GetInt("errors/dataplatform/workflow/sender/maxNumberOfMessages", () => 1000),
                AppSettingsReader.GetString("errors/dataplatform/workflow/sender/messageFilePath",
                    () => @"D:\DataplatformRecoveries\DataProviders\Sender"),
                AppSettingsReader.GetString("errors/dataplatform/workflow/sender/errorQueueName", () => "DataPlatform.DataProvider.Error"));
        }
        public IQueueOptions Options { get; private set; }
    }
}