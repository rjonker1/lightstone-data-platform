﻿using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Moq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using PackageBuilder.Domain.Entities.DataProviders.Read;
using PackageBuilder.Domain.EventHandlers.DataProviders;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Handlers.EventHandlers.DataProviders
{
    public class when_creating_a_data_provider : Specification
    {
        private readonly Mock<IRepository<DataProvider>> _repository = new Mock<IRepository<DataProvider>>();
        private DataProviderCreatedHandler _handler;

        public override void Observe()
        {
            var command = new DataProviderCreated(Guid.NewGuid(), DataProviderName.IVIDVerify_E_WS, "Ivid", 10m, typeof(IProvideDataFromIvid), "Owner", DateTime.UtcNow, null, new[] { DataFieldMother.LicenseField }, 1);
            _handler = new DataProviderCreatedHandler(_repository.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save()
        {
            _repository.Verify(s => s.Save(It.IsAny<DataProvider>()), Times.Once);
        }
    }
}