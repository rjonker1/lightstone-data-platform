using Castle.Windsor;
using Castle.Windsor.Installer;
using Common.Logging;
using EasyNetQ;
using Workflow.Billing.Consumer.Installers;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog _log = LogManager.GetLogger<BillingService>();
        private IBus bus;

        public void Start()
        {
            _log.DebugFormat("Started billing service");

            var container = new WindsorContainer().Install(
                new NHibernateInstaller(),
                new WindsorInstaller(),
                new BusInstaller(),
                new MappingTypeInstaller(),
                new RepositoryInstaller(),
                new ConsumerInstaller());

            bus = container.Resolve<IBus>();

            _log.DebugFormat("Billing service started");
        }

        public void Stop()
        {
            if (bus != null)
            {
                bus.Dispose();
            }

           _log.DebugFormat("Stopped billing service");
        }
    }
}