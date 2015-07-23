using System;
using DataPlatform.Shared.Enums;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Infrastructure.Repositories;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Handlers.CommandHandlers.DataProviders
{
    public class when_creating_a_data_provider : BaseTestHelper
    {
        private CreateDataProviderHandler _handler;
        private readonly Mock<IDataProviderRepository> _readRepository = new Mock<IDataProviderRepository>();
        private readonly Mock<INEventStoreRepository<DataProvider>> _writeRepository = new Mock<INEventStoreRepository<DataProvider>>();
        public override void Observe()
        {
            var command = new CreateDataProvider(Guid.NewGuid(), DataProviderName.Ivid, 10m, "User", DateTime.UtcNow);
            _handler = new CreateDataProviderHandler(_writeRepository.Object, _readRepository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_check_for_existing_entity()
        {
            _readRepository.Verify(s => s.Exists(It.IsAny<Guid>(), DataProviderName.Ivid), Times.Once);
        }

        [Observation]
        public void should_save()
        {
            _writeRepository.Verify(s => s.Save(It.IsAny<DataProvider>(), It.IsAny<Guid>(), true), Times.Once);
        }
    }
}