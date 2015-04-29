using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Moq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.Read;
using PackageBuilder.Domain.EventHandlers.DataProviders;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.EventHandlers.DataProviders
{
    public class when_updating_a_data_provider : Specification
    {
        private readonly Mock<IRepository<DataProvider>> _repository = new Mock<IRepository<DataProvider>>();
        private DataProviderUpdatedHandler _handler;

        public override void Observe()
        {
            var command = new DataProviderUpdated(Guid.NewGuid(), DataProviderName.Ivid, "Ivid", 10m, typeof(IProvideDataFromIvid), false, 1, "Owner", DateTime.UtcNow, null, null, new []{ DataFieldMother.LicenseField });
            _handler = new DataProviderUpdatedHandler(_repository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save()
        {
            _repository.Verify(s => s.Save(It.IsAny<DataProvider>()), Times.Once);
        }
    }
}