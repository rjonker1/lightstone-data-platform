using System.Collections.Generic;
using System.Linq;
using Autofac;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using DataPlatform.Shared.Messaging;
using NEventStore;
using NEventStore.Dispatcher;
using NEventStore.Persistence.Sql.SqlDialects;
using NServiceBus;
using Workflow.Lace.Domain;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.RabbitMq;

namespace Worflow.Transactions.Service.Write.Host
{
    public class WriteModule : Module
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
            builder.RegisterType<RabbitConsumer>().As<IConsumeQueue>();
            builder.RegisterType<QueueInitialization>().As<IInitializeQueues>();
        }

        private static IStoreEvents BuildEventStore(ILifetimeScope container)
        {
            return Wireup.Init()
                .LogToConsoleWindow()
                .UsingSqlPersistence("workflow/transactions/database/write")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                //.UsingBinarySerialization()
                .UsingJsonSerialization()
                //.Compress()
                //.UsingEventUpconversion()
                .UsingAsynchronousDispatchScheduler()
                .DispatchTo(new DelegateMessageDispatcher(c => DispatchCommits(container, c)))
                .Build();
        }

        private static void DispatchCommits(ILifetimeScope container, ICommit commit)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var bus = scope.Resolve<IBus>();

                for (var i = 0; i < commit.Events.Count; i++)
                {
                    var eventMessage = commit.Events.ToArray()[i];
                    var busMessage = eventMessage.Body as IPublishableMessage;
                    AppendHeaders(busMessage, commit.Headers, bus);
                    AppendHeaders(busMessage, eventMessage.Headers, bus);
                    AppendVersion(commit, i, bus);
                    bus.Publish(busMessage);
                }
            }
        }

        private static void AppendHeaders(IPublishableMessage message, IEnumerable<KeyValuePair<string, object>> headers, ISendOnlyBus bus)
        {
            headers = headers.Where(x => x.Key.StartsWith(BusPrefixKey));
            foreach (var header in headers)
            {
                var key = header.Key.Substring(BusPrefixKey.Length);
                var value = (header.Value ?? string.Empty).ToString();
                bus.SetMessageHeader(message, key, value);
            }
        }
        private static void AppendVersion(ICommit commit, int index, ISendOnlyBus bus)
        {
            var busMessage = commit.Events.ToArray()[index].Body as IPublishableMessage;
            bus.SetMessageHeader(busMessage, AggregateIdKey, commit.StreamId.ToString());
            bus.SetMessageHeader(busMessage, CommitVersionKey, commit.StreamRevision.ToString());
            bus.SetMessageHeader(busMessage, EventVersionKey, GetSpecificEventVersion(commit, index).ToString());
        }
        private static int GetSpecificEventVersion(ICommit commit, int index)
        {
            // e.g. (StreamRevision: 120) - (5 events) + 1 + (index @ 4: the last index) = event version: 120
            return commit.StreamRevision - commit.Events.Count + 1 + index;
        }
    }
}
