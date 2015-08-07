using System.Runtime.Serialization;
using Recoveries.Core;

namespace Recoveries.ErrorQueues.DataProviders
{
    [DataContract]
    public class BillingRecoveryConfiguration : IErrorQueueConfiguration
    {
        public BillingRecoveryConfiguration()
        {
            Options = new QueueOptions(
                AppSettingsReader.GetString("errors/dataplatform/billing/transactions/queue", () => "DataPlatform.Transactions.Billing"),
                AppSettingsReader.GetString("rabbitmq/hostname", () => "localhost"),
                AppSettingsReader.GetString("rabbitmq/virtualhost", () => @"/"),
                AppSettingsReader.GetString("rabbitmq/username", () => "guest"),
                AppSettingsReader.GetString("rabbitmq/password", () => "guest"),
                AppSettingsReader.GetBool("errors/dataplatform/billing/transactions/needHandshake", () => false),
                AppSettingsReader.GetInt("errors/dataplatform/billing/transactions/maxNumberOfMessages", () => 1000),
                AppSettingsReader.GetString("errors/dataplatform/billing/transactions/messageFilePath",
                    () => @"D:\DataplatformRecoveries\DataProviders\Billing"),
                AppSettingsReader.GetString("errors/dataplatform/billing/transactions/errorQueueName", () => "DataPlatform.Transactions.Billing.Error"));
        }

        [DataMember]
        public IQueueOptions Options { get; private set; }
    }
}