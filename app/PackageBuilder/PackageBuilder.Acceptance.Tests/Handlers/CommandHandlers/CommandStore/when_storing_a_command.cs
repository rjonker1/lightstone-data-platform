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
using Xunit;

namespace PackageBuilder.Acceptance.Tests.Handlers.CommandHandlers.CommandStore
{
    public class when_storing_a_command : TestDataBaseHelper
    {
        private StoreCommandHandler _handler;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.RefreshDb();

            _repository = new Repository<Command>(Session);

            var createDataProvider = new CreateDataProvider(Guid.NewGuid(), DataProviderName.LSAutoSpecs_I_DB, 0m, "Owner", DateTime.UtcNow);
            var command = new StoreCommand(Guid.NewGuid(), createDataProvider);
            _handler = new StoreCommandHandler(_repository);
            _handler.Handle(command);

            Session.Flush();
        }

        [Fact(Skip = "Manual Test")]
        public void should_store_command()
        {
            
        }
    }

    public class when_replaying_a_command : TestDataBaseHelper
    {
        private ReplayCommandHandler _replayCommandHandler;
        private IBus _bus;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.RefreshDb();

            Container.Install(new WindsorInstaller(), new CommandInstaller(), new BusInstaller(), new NEventStoreInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _repository = new Repository<Command>(Session);
            _bus = Container.Resolve<IBus>();
            _replayCommandHandler = new ReplayCommandHandler(_repository, _bus);

            //new when_storing_a_command().Observe();

            _replayCommandHandler.Handle(new ReplayCommand());
        }

        [Fact(Skip = "Manual Test")]
        public void should_replay_command()
        {

        }
    }
}