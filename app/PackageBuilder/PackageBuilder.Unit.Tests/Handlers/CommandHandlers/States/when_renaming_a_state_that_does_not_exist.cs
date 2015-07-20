using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestObjects.Mothers;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Handlers.CommandHandlers.States
{
    public class when_renaming_a_state_that_does_not_exist : Specification
    {
        private RenameStateHandler _renameHandler;
        private readonly Mock<IStateRepository> _repo = new Mock<IStateRepository>();
        private Exception _exception;
        public override void Observe()
        {
            var renameCommand = new RenameState(Guid.NewGuid(), StateMother.Published.Name, StateMother.Published.Alias);
            _renameHandler = new RenameStateHandler(_repo.Object);
            _exception = Assert.Throws<ArgumentNullException>(() => _renameHandler.Handle(renameCommand));
        }

        [Observation]
        public void should_throw_exception()
        {
            _exception.Message.ShouldContain("Could not retrieve state with id");
        }
    }
}