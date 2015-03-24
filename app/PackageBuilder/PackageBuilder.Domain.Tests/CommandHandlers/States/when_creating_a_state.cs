using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.States;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Packages
{
    public class when_creating_a_state : when_not_persisting_entities
    {
        private CreateStateHandler _handler;
        private readonly Mock<IStateRepository> _repo = new Mock<IStateRepository>();
        public override void Observe()
        {
            base.Observe();
            var command = new CreateState(Guid.NewGuid(), StateName.Published);
            _handler = new CreateStateHandler(_repo.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_check_for_existing_entity()
        {
            _repo.Verify(s => s.Exists(It.IsAny<Guid>(), StateName.Published), Times.Once);
        }

        [Observation]
        public void should_save()
        {
            _repo.Verify(s => s.Save(It.IsAny<State>()), Times.Once);
        }
    }
}