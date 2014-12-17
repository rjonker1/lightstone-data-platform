using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.Packages;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Packages
{
    public class when_creating_a_package : Specification
    {
        private CreatePackageHandler _handler;
        private readonly Mock<IPackageRepository> _readRepository = new Mock<IPackageRepository>();
        private readonly Mock<INEventStoreRepository<Package>> _writeRepository = new Mock<INEventStoreRepository<Package>>();
        public override void Observe()
        {
            var command = new CreatePackage(Guid.NewGuid(), "Name", "Description", 10d, 20d, "Notes", new[] { IndustryMother.Automotive }, StateMother.Draft, "Owner", DateTime.Now, null, new List<DataProviderOverride> { DataProviderOverrideMother.Ivid }.AsEnumerable());
            _handler = new CreatePackageHandler(_writeRepository.Object, _readRepository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save()
        {
            _writeRepository.Verify(s => s.Save(It.IsAny<Package>(), It.IsAny<Guid>()), Times.Once);
        }
    }
}