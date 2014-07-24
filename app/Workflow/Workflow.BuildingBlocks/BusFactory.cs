using System;
using System.Linq;
using BuildingBlocks.Configuration;
using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Workflow.BuildingBlocks.Consumers;
using Workflow.BuildingBlocks.Dispatcher;

namespace Workflow.BuildingBlocks
{
    public class BusFactory
    {
        private const string DefaultConnection = "host=localhost";
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        [Obsolete]
        public IBus CreateConsumerBus(string connectionStringKey, ConsumerRegistration consumers)
        {
            var appSettings = new AppSettings();
            var connectionString = appSettings.ConnectionStrings.Get(connectionStringKey, () => DefaultConnection);
            var subscriptionPrefix = appSettings.RabbitMQ.SubscriptionPrefix;

            try
            {
                var bus = CreateBus(connectionStringKey, null);

                var dispatcher = new NoMagicAutoDispatcher(consumers);
                var autoSubscriber = new AutoSubscriber(bus, subscriptionPrefix)
                                     {
                                         AutoSubscriberMessageDispatcher = dispatcher
                                     };

                var consumerAssemblies = consumers.GetAssemblies();
                autoSubscriber.Subscribe(consumerAssemblies);
                

                Log.DebugFormat("Connected to RabbitMQ on {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                return bus;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Failed to create a bus for RabbitMQ with connectionstring: {0}", connectionString);
                Log.ErrorFormat("The failure was {0}", e.Message);

                throw;
            }
        }


        public static IBus CreateBus(string connectionStringKey)
        {
            var appSettings = new AppSettings();
            var connectionString = appSettings.ConnectionStrings.Get(connectionStringKey, () => DefaultConnection);
            var subscriptionPrefix = appSettings.RabbitMQ.SubscriptionPrefix;

            try
            {

                Log.InfoFormat("Connecting to RabbitMQ via {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                var logger = new RabbitMQLogger();

                var bus = RabbitHutch.CreateBus(connectionString, x => x.Register<IEasyNetQLogger>(p => logger));

                Log.DebugFormat("Connected to RabbitMQ on {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                return bus;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Failed to create a bus for RabbitMQ with connectionstring: {0}", connectionString);
                Log.ErrorFormat("The failure was {0}", e.Message);

                throw;
            }

        }

        public IBus CreateBus(string connectionStringKey, IWindsorContainer container)
        {
            var appSettings = new AppSettings();
            var connectionString = appSettings.ConnectionStrings.Get(connectionStringKey, () => DefaultConnection);
            var subscriptionPrefix = appSettings.RabbitMQ.SubscriptionPrefix;

            try
            {

                Log.InfoFormat("Connecting to RabbitMQ via {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                var logger = new RabbitMQLogger();

                var bus = RabbitHutch.CreateBus(connectionString, x => x.Register<IEasyNetQLogger>(p => logger));
                var autoSubscriber = new AutoSubscriber(bus, subscriptionPrefix)
                {
                    AutoSubscriberMessageDispatcher = new WindsorMessageDispatcher(container)
                };

                var registration = new ConsumerRegistration();
                var assemblies = registration.GetAssemblies(container);

                autoSubscriber.Subscribe(assemblies.ToArray());
                autoSubscriber.SubscribeAsync(assemblies.ToArray());

                Log.DebugFormat("Connected to RabbitMQ on {0} and using subscription prefix {1}", connectionString, subscriptionPrefix);

                return bus;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Failed to create a bus for RabbitMQ with connectionstring: {0}", connectionString);
                Log.ErrorFormat("The failure was {0}", e.Message);

                throw;
            }
        }
    }
}