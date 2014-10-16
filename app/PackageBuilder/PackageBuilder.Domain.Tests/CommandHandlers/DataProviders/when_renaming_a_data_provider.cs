using System;
using Moq;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.DataProviders;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.DataProviders
{
    public class when_renaming_a_data_provider : Specification
    {
        private RenameDataProviderHandler _handler;
        private readonly Mock<INEventStoreRepository<DataProvider>> _eventStoreRepository = new Mock<INEventStoreRepository<DataProvider>>();
        public override void Observe()
        {
            _eventStoreRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(DataProviderMother.Ivid);

            var command = new RenameDataProvider(Guid.NewGuid(), "IVID");
            _handler = new RenameDataProviderHandler(_eventStoreRepository.Object);
            _handler.Handle(command);
        }
    }
}