using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using EasyNetQ;
using Workflow.Reporting.Consumer.Installers;

namespace Workflow.Reporting.Consumer
{
    public class ReportingService : IReportingService
    {

        private IAdvancedBus advancedBus;

        public void Start()
        {
            this.Info(() => "Started reporting service");

            var container = new WindsorContainer().Install(
                new WindsorInstaller(),
                new BusInstaller());

            advancedBus = container.Resolve<IAdvancedBus>();
        }

        public void Stop()
        {
            if (advancedBus != null)
            {
                advancedBus.Dispose();
            }

            this.Info(() => "Stopped reporting service");
        }
    }
}