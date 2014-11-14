using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using Monitoring.Domain.Core;
using Monitoring.Domain.Messages;
using Monitoring.Write.Service;
using NEventStore;
using NEventStore.Persistence.SqlPersistence.SqlDialects;
using NServiceBus;
using NServiceBus.Transports;
using NServiceBus.Unicast;
using Module = Autofac.Module;

/*
 * Important to Bind the Denormalizer queue to the Host. This is done using Rabbit MQ Adminisration 
 * Host Exchange -> Bind the Denormalizing Host to the Host
 *  
 */
namespace Monitoring.DistributedService.Host.IoC
{
    public class DomainModule : Module
    {
        private const string AggregateIdKey = "AggregateId";
        private const string CommitVersionKey = "CommitVersion";
        private const string EventVersionKey = "EventVersion";
        private const string BusPrefixKey = "Bus.";

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => BuildEventStore(c.Resolve<ILifetimeScope>()))
                .As<IStoreEvents>()
                .SingleInstance();

            builder.RegisterType<ConflictDetector>().As<IDetectConflicts>();
            builder.RegisterType<EventStoreRepository>().As<IRepository>();
            builder.RegisterType<AggregateFactory>().As<IConstructAggregates>();
        }

        private static IStoreEvents BuildEventStore(ILifetimeScope container)
        {
            return Wireup.Init()
                .LogToConsoleWindow()
                //.UsingRavenPersistence("EventStore")
                .UsingSqlPersistence("Monitoring.EventStore")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                .UsingBinarySerialization()
                .Compress()
                //.UsingAsynchronousDispatchScheduler()
                //.DispatchTo(new DelegateMessageDispatcher(c => DispatchCommit(container, c)))
                .Build();
        }

        private static void DispatchCommit(ILifetimeScope container, Commit commit)
        {
          
            using (var scope = container.BeginLifetimeScope())
            {
                var publisher = scope.Resolve<IPublishMessages>();

                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events[i];
                    var busMessage = new TransportMessage() //eventMessage.Body as TransportMessage;
                    {
                        Body = Encoding.UTF8.GetBytes(eventMessage.Body.AsJsonString())
                    };
                    AppendHeaders(busMessage, commit.Headers);
                    AppendHeaders(busMessage, eventMessage.Headers);
                    AppendVersion(commit, i);

                    publisher.Publish(busMessage, new PublishOptions(typeof(IDataProviderMonitoringEvent)));
                }
            }
        }

        private static void AppendHeaders(TransportMessage message, IEnumerable<KeyValuePair<string, object>> headers)
        {
            headers = headers.Where(x => x.Key.StartsWith(BusPrefixKey));
            foreach (var header in headers)
            {
                var key = header.Key.Substring(BusPrefixKey.Length);
                var value = (header.Value ?? string.Empty).ToString();
                message.Headers.Add(key, value);
            }
        }

        private static void AppendVersion(Commit commit, int index)
        {
            //var busMessage = commit.Events[index].Body as TransportMessage;
            var busMessage = new TransportMessage() //eventMessage.Body as TransportMessage;
            {
                Body = Encoding.UTF8.GetBytes(commit.Events[index].Body.AsJsonString())
            };

            busMessage.Headers.Add(AggregateIdKey, commit.StreamId.ToString());
            busMessage.Headers.Add(CommitVersionKey, commit.StreamRevision.ToString());
            busMessage.Headers.Add(EventVersionKey, GetSpecificEventVersion(commit, index).ToString());
        }

        private static int GetSpecificEventVersion(Commit commit, int index)
        {
            // e.g. (StreamRevision: 120) - (5 events) + 1 + (index @ 4: the last index) = event version: 120
            return commit.StreamRevision - commit.Events.Count + 1 + index;
        }
        
    }
}
