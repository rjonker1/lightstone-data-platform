using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Reports.Billing", ExchangeName = "DataPlatform.Reports.Billing")]
    public class ReportMessage : Entity
    {
        public virtual string ReportBody { get; set; }
        public virtual string ReportType { get; set; }

        public ReportMessage()
        {
        }
    }
}