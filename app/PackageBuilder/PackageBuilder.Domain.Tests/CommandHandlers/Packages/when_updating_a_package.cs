using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.Packages;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Packages
{
    public class when_updating_a_package : when_not_persisting_entities
    {
        private UpdatePackageHandler _handler;
        private readonly Mock<IPackageRepository> _readRepository = new Mock<IPackageRepository>();
        private readonly Mock<INEventStoreRepository<Package>> _writeRepository = new Mock<INEventStoreRepository<Package>>();
        public override void Observe()
        {
            base.Observe();
            var command = new UpdatePackage(Guid.NewGuid(), "Name", "Description", 10m, 20m, "Notes", new[] { IndustryMother.Automotive }, StateMother.Draft, 1, "Owner", DateTime.UtcNow, DateTime.UtcNow, new List<IDataProviderOverride> { DataProviderOverrideMother.Ivid }.AsEnumerable());
            _handler = new UpdatePackageHandler(_writeRepository.Object, _readRepository.Object);

            _writeRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(WritePackageMother.FullVerificationPackage);

            _handler.Handle(command);
        }

        [Observation]
        public void should_check_for_existing_entity()
        {
            _readRepository.Verify(s => s.Exists(It.IsAny<Guid>(), "Name"), Times.Once);
        }

        [Observation]
        public void should_get_latest_version()
        {
            _writeRepository.Verify(s => s.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Observation]
        public void should_save()
        {
            _writeRepository.Verify(s => s.Save(It.IsAny<Package>(), It.IsAny<Guid>()), Times.Once);
        }
    }
}