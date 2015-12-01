using System;
using System.Collections;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Newtonsoft.Json;
using Shared.Logging;
using Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers
{
    public class BillingReport : IPublishReportQueue<BillingReport>
    {
        private readonly IAdvancedBus _bus;

        public BillingReport(IAdvancedBus bus)
        {
            _bus = bus;
        }

        public void PublishToQueue(IList reportList, string reportType)
        {
            var bus = new TransactionBus(_bus);

            this.Info(() => "FinalBilling reports processing to queue started for report type: {0}".FormatWith(reportType));

            foreach (var report in reportList)
            {
                bus.SendDynamic(new ReportMessage
                {
                    Id = Guid.NewGuid(),
                    ReportBody = JsonConvert.SerializeObject(report),
                    ReportType = reportType
                });
            }

            this.Info(() => "FinalBilling reports processing queue completed for report type: {0}".FormatWith(reportType));
        }
    }
}