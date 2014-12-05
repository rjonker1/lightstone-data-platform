using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class ImportDataProviderHandler : AbstractMessageHandler<ImportDataProvider>
    {
        private readonly IHandleMessages _handler;

        public ImportDataProviderHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportDataProvider command)
        {
            _handler.Handle(new CreateDataProvider(IvidResponseMother.Response, Guid.NewGuid(), DataProviderName.Ivid, DataProviderName.Ivid.ToString(), 0d, typeof(IProvideDataFromIvid), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(IvidTitleHolderResponseMother.Response, Guid.NewGuid(), DataProviderName.IvidTitleHolder, DataProviderName.IvidTitleHolder.ToString(), 0d, typeof(IProvideDataFromIvidTitleHolder), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(LightstoneResponseMother.Response, Guid.NewGuid(), DataProviderName.Lightstone, DataProviderName.Lightstone.ToString(), 0d, typeof(IProvideDataFromLightstone), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(RgtResponseMother.Response, Guid.NewGuid(), DataProviderName.Rgt, DataProviderName.Rgt.ToString(), 0d, typeof(IProvideDataFromRgt), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(RgtVinResponseMother.Response, Guid.NewGuid(), DataProviderName.RgtVin, DataProviderName.RgtVin.ToString(), 0d, typeof(IProvideDataFromRgtVin), "Owner", DateTime.Now));
        }
    }
}