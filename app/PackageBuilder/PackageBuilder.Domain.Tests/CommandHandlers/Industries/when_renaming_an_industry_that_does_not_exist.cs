using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.Industries;
using PackageBuilder.Domain.Entities.Industries.Commands;
using Raven.Client;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Industries
{
    public class when_renaming_an_industry_that_does_not_exist : Specification
    {
        private RenameIndustryHandler _renameHandler;
        private readonly Mock<IDocumentSession> _session = new Mock<IDocumentSession>();
        private Exception _exception;
        public override void Observe()
        {
            var renameCommand = new RenameIndustry(Guid.NewGuid(), "Test Industry 2");
            _renameHandler = new RenameIndustryHandler(_session.Object);
            _exception = Assert.Throws<ArgumentNullException>(() => _renameHandler.Handle(renameCommand));
        }

        [Observation]
        public void should_throw_exception()
        {
            _exception.Message.ShouldContain("Could not load industry with id");
        }
    }
}