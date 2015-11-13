using Castle.Windsor;
using DataPlatform.Shared.Helpers.Extensions;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Workflow.Reporting.Consumer.Installers;
using Workflow.Reporting.Consumers;

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
                new BusInstaller(),
                new NotificationInstaller(),
                new ConsumerInstaller());

            advancedBus = container.Resolve<IAdvancedBus>();
            var q = advancedBus.QueueDeclare("DataPlatform.Reports.Billing");

            advancedBus.Consume(q, x => x
                .Add<ReportMessage>((message, info) => new TransactionConsumer<ReportMessage>(message, container)));
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