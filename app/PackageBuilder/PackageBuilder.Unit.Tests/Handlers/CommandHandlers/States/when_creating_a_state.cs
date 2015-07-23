using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.States;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Infrastructure.Repositories;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Handlers.CommandHandlers.States
{
    public class when_creating_a_state : Specification
    {
        private readonly Mock<IStateRepository> _repo = new Mock<IStateRepository>();

        public when_creating_a_state()
        {
            var command = new CreateState(Guid.NewGuid(), StateName.Published);
            var handler = new CreateStateHandler(_repo.Object);
            handler.Handle(command);
        }

        public override void Observe()
        {

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