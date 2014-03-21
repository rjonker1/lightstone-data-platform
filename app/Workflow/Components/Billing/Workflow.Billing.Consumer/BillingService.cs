using System;
using BuildingBlocks.Configuration;
using Common.Logging;
using EasyNetQ;

namespace Workflow.Billing.Consumer
{
    public class BillingService : IBillingService
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();
        private IBus bus;
        private const string defaultConnection = "host=localhost";

        public BillingService()
        {
        }

        public void Start()
        {
            log.DebugFormat("Started billing service");
            try
            {
                var connectionString = new AppSettings().ConnectionStrings.Get("workflow/billing/queue", () => defaultConnection);

                log.InfoFormat("Connecting to RabbitMQ via {0}", connectionString);

                var logger = new RabbitMQLogger();
                bus = RabbitHutch.CreateBus(connectionString, x => x.Register<IEasyNetQLogger>(_ => logger));

                log.DebugFormat("Connected to RabbitMQ on {0}", connectionString);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Failed to create a bus for RabbitMQ because: {0}", e.Message);
            }
        }

        public void Stop()
        {
            if (bus != null)
            {
                bus.Dispose();
            }

            log.DebugFormat("Stopped billing service");
        }
    }
}