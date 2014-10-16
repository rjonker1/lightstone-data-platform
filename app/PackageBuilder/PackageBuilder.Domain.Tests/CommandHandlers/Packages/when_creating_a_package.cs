using System;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.Packages;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Packages
{
    public class when_creating_a_package : Specification
    {
        private CreatePackageHandler _handler;
        private readonly Mock<INEventStoreRepository<Package>> _eventStoreRepository = new Mock<INEventStoreRepository<Package>>();
        public override void Observe()
        {
            var command = new CreatePackage(Guid.NewGuid(), "VVi", new[] { DataProviderMother.Ivid, DataProviderMother.Audatex });
            _handler = new CreatePackageHandler(_eventStoreRepository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save()
        {
            _eventStoreRepository.Verify(s => s.Save(It.IsAny<Package>(), It.IsAny<Guid>()), Times.Once);
        }
    }
}