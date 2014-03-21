﻿using System;
using System.Collections.Generic;
using BuildingBlocks.Configuration;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;

namespace Workflow.BuildingBlocks
{
    public class XXX
    {
    }

    public class NullConsumer : IConsume<XXX>
    {
        public void Consume(XXX message)
        {
        }
    }

    public class BusFactory
    {
        private const string defaultConnection = "host=localhost";
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public IBus Create(string connectionStringKey, List<ConsumerRegistration> consumers)
        {
            var appSettings = new AppSettings();
            var connectionString = appSettings.ConnectionStrings.Get(connectionStringKey, () => defaultConnection);
            var subscriptionPrefix = appSettings.RabbitMQ.SubscriptionPrefix;

            try
            {

                log.InfoFormat("Connecting to RabbitMQ via {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                var logger = new RabbitMQLogger();
                var bus = RabbitHutch.CreateBus(connectionString, x => x.Register<IEasyNetQLogger>(_ => logger));

                var dispatcher = new NoMagicAutoDispatcher(consumers);
                var autoSubscriber = new AutoSubscriber(bus, subscriptionPrefix)
                                     {
                                         AutoSubscriberMessageDispatcher = dispatcher
                                     };
                

                log.DebugFormat("Connected to RabbitMQ on {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                return bus;
            }
            catch (Exception e)
            {
                log.ErrorFormat("Failed to create a bus for RabbitMQ with connectionstring: {0}", connectionString);
                log.ErrorFormat("The failure was {0}", e.Message);

                throw;
            }
        }
    }
}