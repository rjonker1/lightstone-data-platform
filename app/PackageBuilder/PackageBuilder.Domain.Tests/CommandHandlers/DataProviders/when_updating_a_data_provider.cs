using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Entities;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.DataProviders
{
    public class when_updating_a_data_provider : when_not_persisting_entities
    {
        private UpdateDataProviderHandler _handler;
        private readonly Mock<IDataProviderRepository> _readRepository = new Mock<IDataProviderRepository>();
        private readonly Mock<INEventStoreRepository<DataProvider>> _writeRepository = new Mock<INEventStoreRepository<DataProvider>>();
        public override void Observe()
        {
            base.Observe();

            var command = new UpdateDataProvider(Guid.NewGuid(), DataProviderName.Ivid, "Description", 10d, typeof(IvidResponse), false, StateMother.Published, 1, "Owner", DateTime.UtcNow, null, new []{ DataFieldMother.LicenseField });
            _handler = new UpdateDataProviderHandler(_writeRepository.Object, _readRepository.Object);

            _writeRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(WriteDataProviderMother.Ivid);
            _handler.Handle(command);
        }

        [Observation]
        public void should_check_for_existing_entity()
        {
            _readRepository.Verify(s => s.Exists(It.IsAny<Guid>(), DataProviderName.Ivid), Times.Once);
        }

        [Observation]
        public void should_get_latest_version()
        {
            _writeRepository.Verify(s => s.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Observation]
        public void should_save()
        {
            _writeRepository.Verify(s => s.Save(It.IsAny<DataProvider>(), It.IsAny<Guid>()), Times.Once);
        }
    }
}