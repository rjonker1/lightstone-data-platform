using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;
using RestSharp;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Reports.Billing", ExchangeName = "DataPlatform.Reports.Billing")]
    public class ReportMessage : Entity
    {
        public virtual JsonObject reportBody {get; set; }

        public ReportMessage()
        {
        }
    }
}