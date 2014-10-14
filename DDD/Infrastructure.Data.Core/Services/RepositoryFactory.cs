using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using Raven.Abstractions.Exceptions;
using Raven.Client;
using Topics.Radical.Linq;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        private readonly ICommitDispatchScheduler commitDispatcher;
        private readonly Commit.Factory commitFactory;
        private readonly IOperationContextManager contextManager;
        private readonly IDocumentStore store;
        private readonly ILoggerFactory loggerFactory;

        public RepositoryFactory(IOperationContextManager contextManager, IDocumentStore store,
            ICommitDispatchScheduler commitDispatcher, Commit.Factory commitFactory, ILoggerFactory loggerFactory)
        {
            Ensure.That(contextManager).Named(() => contextManager).IsNotNull();
            Ensure.That(store).Named(() => store).IsNotNull();
            Ensure.That(commitDispatcher).Named(() => commitDispatcher).IsNotNull();
            Ensure.That(commitFactory).Named(() => commitFactory).IsNotNull();

            this.contextManager = contextManager;
            this.store = store;
            this.commitDispatcher = commitDispatcher;
            this.commitFactory = commitFactory;
            this.loggerFactory = loggerFactory;
        }

        public IRepository OpenSession()
        {
            return new Repository(
                contextManager,
                store.OpenSession(),
                commitDispatcher,
                commitFactory,
                loggerFactory);
        }

        private class Repository : IRepository
        {
            private readonly HashSet<IAggregate> aggregateTracking = new HashSet<IAggregate>();
            private readonly ICommitDispatchScheduler commitDispatchScheduler;
            private readonly Commit.Factory commitFactory;
            private readonly IOperationContextManager contextManager;
            private readonly IDocumentSession session;
            private readonly Guid txId;
            private readonly ILogger Ilogger ;

            public Repository(IOperationContextManager contextManager, IDocumentSession session, ICommitDispatchScheduler commitDispatchScheduler, Commit.Factory commitFactory, ILoggerFactory loggerFactory)
            {
                Ensure.That(contextManager).Named(() => contextManager).IsNotNull();
                Ensure.That(session).Named(() => session).IsNotNull();
                Ensure.That(commitDispatchScheduler).Named(() => commitDispatchScheduler).IsNotNull();
                Ensure.That(commitFactory).Named(() => commitFactory).IsNotNull();

                txId = Guid.NewGuid();

                this.contextManager = contextManager;
                this.session = session;
                this.session.Advanced.UseOptimisticConcurrency = true;
                this.commitDispatchScheduler = commitDispatchScheduler;
                this.commitFactory = commitFactory;
                this.Ilogger = loggerFactory.Create();
            }

            public void Dispose()
            {
                session.Dispose();

                aggregateTracking.Clear();
            }

            public void Save<TAggregate>(TAggregate aggregate) where TAggregate : IAggregate
            {
                session.Store(aggregate);

                TrackIfRequired(aggregate);
            }

            public void CommitChanges()
            {
                try
                {
                    IOperationContext operationContext = contextManager.GetCurrent();
                    string correlationId = operationContext.CorrelationId;

                    string userAccount = Thread.CurrentPrincipal.Identity.Name;

                    Commit[] commits = aggregateTracking
                        .Where(a => a.IsChanged)
                        .Select(aggregate => new
                        {
                            Aggregate = aggregate,
                            Commit = commitFactory.CreateFor(txId, correlationId, aggregate, userAccount)
                        })
                        .ToArray()
                        .ForEach(temp =>
                        {
                            IAggregate aggregate = temp.Aggregate;
                            Commit commit = temp.Commit;

                            if (commitDispatchScheduler.IsSynchronous)
                            {
                                commit.MarkAsDispatched();
                            }

                            session.Store(commit);
                        })
                        .Select(temp => temp.Commit)
                        .ToArray();

                    session.SaveChanges();

                    aggregateTracking.ForEach(a => a.ClearUncommittedEvents());
                    aggregateTracking.Clear();

                    commitDispatchScheduler.ScheduleDispatch(commits);
                }
                catch (LightstoneApp.Infrastructure.CrossCutting.NetFramework.ConcurrencyException cex)
                {
                    // log
                    Ilogger.Error("ConcurrencyException", cex,null);
                    throw;
                }
            }

            public TAggregate GetById<TAggregate>(string aggregateId) where TAggregate : IAggregate
            {
                var aggregate = session.Load<TAggregate>(aggregateId);
                TrackIfRequired(aggregate);

                return aggregate;
            }

            public TAggregate[] GetById<TAggregate>(params string[] aggregateIds) where TAggregate : IAggregate
            {
                TAggregate[] aggregates = session.Load<TAggregate>(aggregateIds);
                foreach (TAggregate a in aggregates)
                {
                    TrackIfRequired(a);
                }

                return aggregates;
            }

            private void TrackIfRequired(IAggregate aggregate)
            {
                if (!aggregateTracking.Contains(aggregate))
                {
                    aggregateTracking.Add(aggregate);
                }
            }
        }
    }
}