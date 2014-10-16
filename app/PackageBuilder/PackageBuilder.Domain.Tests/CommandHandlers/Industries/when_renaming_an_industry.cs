using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.Industries;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.TestHelper.Mothers;
using Raven.Client;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Industries
{
    public class when_renaming_an_existing_industry : Specification
    {
        private RenameIndustryHandler _renameHandler;
        private readonly Mock<IDocumentSession> _session = new Mock<IDocumentSession>();
        public override void Observe()
        {
            _session.Setup(x => x.Load<Industry>(It.IsAny<Guid>())).Returns(IndustryMother.BankIndustry);
            _renameHandler = new RenameIndustryHandler(_session.Object);

            var renameCommand = new RenameIndustry(Guid.NewGuid(), "Test Industry 2");
            _renameHandler.Handle(renameCommand);
        }

        [Observation]
        public void should_load_the_industry()
        {
            _session.Verify(s => s.Load<Industry>(Guid.NewGuid()), Times.AtMostOnce);
        }

        [Observation]
        public void should_update_the_name()
        {
            _session.Object.Load<Industry>(Guid.NewGuid()).Name.ShouldEqual("Test Industry 2");
        }
    }
}