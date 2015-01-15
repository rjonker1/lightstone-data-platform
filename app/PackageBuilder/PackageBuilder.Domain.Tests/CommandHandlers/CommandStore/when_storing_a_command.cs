using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore;
using PackageBuilder.Domain.Entities.CommandStore.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.CommandStore
{
    public class when_storing_a_command : when_persisting_entities_to_db
    {
        private StoreCommandHandler _handler;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.Observe();

            _repository = new Repository<Command>(Session);

            var createDataProvider = new CreateDataProvider(
                new RgtResponse(), 
                Guid.NewGuid(), 
                DataProviderName.Rgt,
                DataProviderName.Rgt.ToString(), 
                0d, 
                typeof (IProvideDataFromRgt), 
                "Owner", 
                DateTime.Now);
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

    public class when_replaying_a_command : when_persisting_entities_to_db
    {
        private ReplayCommandHandler _replayCommandHandler;
        private IHandleMessages _handler;
        private IRepository<Command> _repository;

        public override void Observe()
        {
            base.Observe();

            Container.Install(new WindsorInstaller(), new CommandInstaller());

            _repository = new Repository<Command>(Session);
            _handler = Container.Resolve<IHandleMessages>();
            _replayCommandHandler = new ReplayCommandHandler(_repository, _handler);

            new when_storing_a_command().Observe();

            _replayCommandHandler.Handle(new ReplayCommand());
        }

        [Observation]
        public void should_replay_command()
        {

        }
    }
}