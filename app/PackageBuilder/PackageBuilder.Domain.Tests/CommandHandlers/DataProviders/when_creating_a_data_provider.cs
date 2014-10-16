using System;
using Lace.Models.Ivid.Dto;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.DataProviders
{
    public class when_creating_a_data_provider : Specification
    {
        private CreateDataProviderHandler _handler;
        private readonly Mock<INEventStoreRepository<DataProvider>> _eventStoreRepository = new Mock<INEventStoreRepository<DataProvider>>();
        public override void Observe()
        {
            var command = new CreateDataProvider(Guid.NewGuid(), "IVID", null, typeof(IvidResponse));
            _handler = new CreateDataProviderHandler(_eventStoreRepository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save()
        {
            _eventStoreRepository.Verify(s => s.Save(It.IsAny<DataProvider>(), It.IsAny<Guid>()), Times.Once);
        }
    }
}