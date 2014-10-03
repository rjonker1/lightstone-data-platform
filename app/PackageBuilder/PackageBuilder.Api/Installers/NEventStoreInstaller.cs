using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using MemBus;
using MemBus.Configurators;
using NEventStore;
using NEventStore.Dispatcher;
using PackageBuilder.Core.Events;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.MessageHandling;

namespace PackageBuilder.Api.Installers
{
    public class MessageAdapter : IocAdapter
    {
        private readonly IWindsorContainer _container;

        public MessageAdapter(IWindsorContainer container)
        {
            _container = container;
        }

        public IEnumerable<object> GetAllInstances(Type desiredType)
        {
            yield return _container.Resolve(desiredType);
        }
    }

    public class NEventStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBus>().Instance(BusSetup.StartWith<Conservative>()
                                                                      .Apply<IoCSupport>(s => s.SetAdapter(new MessageAdapter(container))
                                                                      .SetHandlerInterface(typeof(IHandleMessages<>)))
                                                                      .Construct()));
            container.Register(Component.For<IDispatchCommits>().ImplementedBy<InMemoryDispatcher>());

            var eventStore = Wireup.Init()
                .UsingRavenPersistence("packageBuilder/database")
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Compress()
                .EncryptWith(new byte[]
                {
                    0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0xb, 0xc, 0xd, 0xe, 0xf
                })
                .HookIntoPipelineUsing(new[] {new AuthorizationPipelineHook()})
                .UsingSynchronousDispatchScheduler()
                .DispatchTo(container.Resolve<IDispatchCommits>())
                .Build();

            
            container.Register(Component.For<IStoreEvents>().Instance(eventStore));
            container.Register(Component.For<IConstructAggregates>().ImplementedBy<AggregateFactory>());
            container.Register(Component.For<IDetectConflicts>().ImplementedBy<ConflictDetector>());
            container.Register(Component.For(typeof(INEventStoreRepository<>)).ImplementedBy(typeof(NEventStoreRepository<>)));
        }
    }

    public class InMemoryDispatcher : IDispatchCommits
    {
        private readonly IBus _bus;

        public InMemoryDispatcher(IBus bus)
        {
            _bus = bus;
        }

        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Dispatch(ICommit commit)
        {
            foreach (var @event in commit.Events.Where(x => x.Body is IDomainEvent))
                _bus.Publish(@event.Body);
        }
    }

    public class AuthorizationPipelineHook : IPipelineHook
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICommit Select(ICommit committed)
        {
            // return null if the user isn't authorized to see this commit
            return committed;
        }

        public bool PreCommit(CommitAttempt attempt)
        {
            // Can easily do logging or other such activities here
            return true; // true == allow commit to continue, false = stop.
        }

        public void PostCommit(ICommit committed)
        {
            // anything to do after the commit has been persisted.
        }

        protected virtual void Dispose(bool disposing)
        {
            // no op
        }

        public void OnPurge(string bucketId)
        {

        }

        public void OnDeleteStream(string bucketId, string streamId)
        {

        }
    }
}