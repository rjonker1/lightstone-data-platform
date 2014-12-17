using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.States
{
    public class when_renaming_an_existing_state : Specification
    {
        private RenameStateHandler _renameHandler;
        private readonly Mock<IStateRepository> _repo = new Mock<IStateRepository>();
        public override void Observe()
        {
            _repo.Setup(x => x.Get(It.IsAny<Guid>())).Returns(StateMother.Published);
            _renameHandler = new RenameStateHandler(_repo.Object);

            var renameCommand = new RenameState(Guid.NewGuid(), StateMother.Published.Name, StateMother.Published.Alias);
            _renameHandler.Handle(renameCommand);
        }

        [Observation]
        public void should_load_the_state()
        {
            _repo.Verify(s => s.Get(Guid.NewGuid()), Times.AtMostOnce);
        }

        [Observation]
        public void should_update_the_name()
        {
            _repo.Object.Get(Guid.NewGuid()).Name.ShouldEqual(StateMother.Published.Name);
        }
    }
}