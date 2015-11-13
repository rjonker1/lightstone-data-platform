using System.Collections;

namespace Workflow.Billing.Domain.Helpers.BillingRunHelpers.Infrastructure
{
    public interface IPublishReportQueue<T> where T : class
    {
        void PublishToQueue(IList reportList, string reportType);
    }
}