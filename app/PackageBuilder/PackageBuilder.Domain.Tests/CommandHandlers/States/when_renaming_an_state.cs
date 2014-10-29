using System;
using Moq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.States
{
    public class when_renaming_an_existing_state : Specification
    {
        private RenameStateHandler _renameHandler;
        private readonly Mock<IRepository<State>> _repo = new Mock<IRepository<State>>();
        public override void Observe()
        {
            _repo.Setup(x => x.Get(It.IsAny<Guid>())).Returns(StateMother.Draft);
            _renameHandler = new RenameStateHandler(_repo.Object);

            var renameCommand = new RenameState(Guid.NewGuid(), StateMother.Published.Name);
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