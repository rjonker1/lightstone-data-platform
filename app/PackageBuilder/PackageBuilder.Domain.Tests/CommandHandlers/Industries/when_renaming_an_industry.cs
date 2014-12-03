using System;
using Moq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.Industries;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Industries
{
    public class when_renaming_an_existing_industry : Specification
    {
        private RenameIndustryHandler _renameHandler;
        private readonly Mock<IRepository<Industry>> _repo = new Mock<IRepository<Industry>>();
        public override void Observe()
        {
            _repo.Setup(x => x.Get(It.IsAny<Guid>())).Returns(IndustryMother.BankIndustry);
            _renameHandler = new RenameIndustryHandler(_repo.Object);

            var renameCommand = new RenameIndustry(Guid.NewGuid(), "Test Industry 2", false);
            _renameHandler.Handle(renameCommand);
        }

        [Observation]
        public void should_load_the_industry()
        {
            _repo.Verify(s => s.Get(Guid.NewGuid()), Times.AtMostOnce);
        }

        [Observation]
        public void should_update_the_name()
        {
            _repo.Object.Get(Guid.NewGuid()).Name.ShouldEqual("Test Industry 2");
        }
    }
}