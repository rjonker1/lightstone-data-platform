using System;
using BuildingBlocks.Configuration;
using Common.Logging;
using EasyNetQ;

namespace Workflow.BuildingBlocks
{
    public class BusFactory
    {
        private const string defaultConnection = "host=localhost";
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public IBus Create(string connectionStringKey)
        {
            try
            {
                var connectionString = new AppSettings().ConnectionStrings.Get(connectionStringKey, () => defaultConnection);
                log.InfoFormat("Connecting to RabbitMQ via {0}", connectionString);

                var logger = new RabbitMQLogger();
                var bus = RabbitHutch.CreateBus(connectionString, x => x.Register<IEasyNetQLogger>(_ => logger));

                log.DebugFormat("Connected to RabbitMQ on {0}", connectionString);

                return bus;
            }
            catch (Exception e)
            {
                log.ErrorFormat("Failed to create a bus for RabbitMQ because: {0}", e.Message);
                throw;
            }
        }
    }
}
