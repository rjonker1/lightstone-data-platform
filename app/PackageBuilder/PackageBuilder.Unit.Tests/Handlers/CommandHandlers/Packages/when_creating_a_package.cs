using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.Packages;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Infrastructure.NEventStore;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit;

namespace PackageBuilder.Unit.Tests.Handlers.CommandHandlers.Packages
{
    public class when_creating_a_package : BaseTestHelper
    {
        private CreatePackageHandler _handler;
        private readonly Mock<IPackageRepository> _readRepository = new Mock<IPackageRepository>();
        private readonly Mock<INEventStoreRepository<Package>> _writeRepository = new Mock<INEventStoreRepository<Package>>();
        public when_creating_a_package()
        {
            var command = new CreatePackage(Guid.NewGuid(), "Name", "Description", 10m, 20m, "Notes", PackageEventType.VehicleVerification,  new[] { IndustryMother.Automotive }, StateMother.Draft, "Owner", DateTime.UtcNow, null, new List<IDataProviderOverride> { DataProviderOverrideMother.Ivid }.AsEnumerable());
            _handler = new CreatePackageHandler(_writeRepository.Object, _readRepository.Object);
            _handler.Handle(command);
        }

        public override void Observe()
        {

        }

        [Fact(Skip = "Needs to be acceptance test")]
        public void should_check_for_existing_entity()
        {
            _readRepository.Verify(s => s.Exists(It.IsAny<Guid>(), "Name"), Times.Once);
        }

        [Fact(Skip = "Needs to be acceptance test")]
        public void should_save()
        {
            _writeRepository.Verify(s => s.Save(It.IsAny<Package>(), It.IsAny<Guid>(), false), Times.Once);
        }
    }
}