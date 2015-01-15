using System;
using Moq;
using PackageBuilder.Domain.Entities.Packages.Events;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Domain.EventHandlers.Packages;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.EventHandlers.DataProviders
{
    public class when_updating_a_package : Specification
    {
        private readonly Mock<IPackageRepository> _repository = new Mock<IPackageRepository>();
        private PackageUpdatedHandler _handler;

        public override void Observe()
        {
            var command = new PackageUpdated(Guid.NewGuid(), "VVi", "VVi", 10d, 20d, "Notes", new[] { IndustryMother.Automotive }, StateMother.Published, 1, 0.1m, "Owner", DateTime.UtcNow, null, new[] { DataProviderOverrideMother.Ivid });
            _handler = new PackageUpdatedHandler(_repository.Object);
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