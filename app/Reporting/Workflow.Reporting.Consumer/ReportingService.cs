using DataPlatform.Shared.Helpers.Extensions;

namespace Workflow.Reporting.Consumer
{
    public class ReportingService : IReportingService
    {

        public void Start()
        {
            this.Info(() => "Started reporting service");
        }

        public void Stop()
        {
            this.Info(() => "Stopped reporting service");
        }
    }
}