using System;
using Moq;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.Read;
using PackageBuilder.Domain.EventHandlers.Packages;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.EventHandlers.DataProviders
{
    public class when_creating_a_package : Specification
    {
        private readonly Mock<IPackageRepository> _repository = new Mock<IPackageRepository>();
        private PackageCreatedHandler _handler;

        public override void Observe()
        {
            var command = new PackageCreated(Guid.NewGuid(), "VVi", "VVi", 10d, 20d, new []{IndustryMother.Automotive}, StateMother.Published, 0.1m, "Owner", DateTime.UtcNow, null, new[] { DataProviderOverrideMother.Ivid });
            _handler = new PackageCreatedHandler(_repository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_check_for_existing_entity()
        {
            _repository.Verify(s => s.Exists(It.IsAny<Guid>(), "VVi"), Times.Once);
        }

        [Observation]
        public void should_save()
        {
            _repository.Verify(s => s.Save(It.IsAny<Package>()), Times.Once);
        }
    }
}