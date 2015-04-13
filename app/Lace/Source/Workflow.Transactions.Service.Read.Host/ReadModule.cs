using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Autofac;
using DataPlatform.Shared.Messaging;
using NEventStore;
using NEventStore.Dispatcher;
using NServiceBus;
using Workflow.Billing.Repository;
using Workflow.Lace.Mappers;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.RabbitMq;

namespace Workflow.Transactions.Service.Read.Host
{
    public class ReadModule : Module
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

            builder.RegisterType<RabbitConsumer>().As<IConsumeQueue>();
            builder.RegisterType<QueueInitialization>().As<IInitializeQueues>();
            builder.Register(
                c =>
                    new Repository(
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["workflow/transactions/database/read"]
                                .ConnectionString), new RepositoryMapper(new MappingForTypes())))
                .As<IRepository>();
        }

        private static IStoreEvents BuildEventStore(ILifetimeScope container)
        {
            return Wireup.Init()
                .LogToConsoleWindow()
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
