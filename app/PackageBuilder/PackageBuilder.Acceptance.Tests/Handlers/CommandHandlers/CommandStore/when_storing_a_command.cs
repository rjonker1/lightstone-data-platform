using System;
using DataPlatform.Shared.Enums;
using MemBus;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Handlers.CommandHandlers.CommandStore
{
    public class when_storing_a_command : when_persisting_entities_to_memory
    {
        private StoreCommandHandler _handler;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.Observe();

            _repository = new Repository<Command>(Session);

            var createDataProvider = new CreateDataProvider(Guid.NewGuid(), DataProviderName.Rgt, 0m, "Owner", DateTime.UtcNow);
            var command = new StoreCommand(Guid.NewGuid(), createDataProvider);
            _handler = new StoreCommandHandler(_repository);
            _handler.Handle(command);

            Session.Flush();
        }

        [Observation]
        public void should_store_command()
        {
            
        }
    }

    public class when_replaying_a_command : when_persisting_entities_to_memory
    {
        private ReplayCommandHandler _replayCommandHandler;
        private IBus _bus;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.Observe();

            Container.Install(new WindsorInstaller(), new CommandInstaller(), new BusInstaller(), new NEventStoreInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _repository = new Repository<Command>(Session);
            _bus = Container.Resolve<IBus>();
            _replayCommandHandler = new ReplayCommandHandler(_repository, _bus);

            //new when_storing_a_command().Observe();

            _replayCommandHandler.Handle(new ReplayCommand());
        }

        [Observation]
        public void should_replay_command()
        {

        }
    }
}