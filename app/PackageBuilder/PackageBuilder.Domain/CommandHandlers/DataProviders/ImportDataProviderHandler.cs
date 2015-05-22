using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.CommandHandlers.DataProviders.Responses;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using AudatexResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.AudatexResponse;
using IvidResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.IvidResponse;
using LightstoneAutoResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.LightstoneAutoResponse;
using LightstonePropertyResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.LightstonePropertyResponse;
using SignioDriversLicenseDecryptionResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.SignioDriversLicenseDecryptionResponse;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders
{
    public class ImportDataProviderHandler : AbstractMessageHandler<ImportDataProvider>
    {
        private readonly IPublishStorableCommands _publisher;

        public ImportDataProviderHandler(IPublishStorableCommands publisher)
        {
            _publisher = publisher;
        }

        public override void Handle(ImportDataProvider command)
        {
            this.Info(() => "Attempting to import data providers");

            _publisher.Publish(new CreateDataProvider(new IvidResponse().DefaultIvidResponse(), Guid.NewGuid(), DataProviderName.Ivid,
                DataProviderName.Ivid.ToString(), 0m, typeof (IProvideDataFromIvid), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new IvidTitleHolderResponse(), Guid.NewGuid(),
                DataProviderName.IvidTitleHolder, DataProviderName.IvidTitleHolder.ToString(), 0m,
                typeof (IProvideDataFromIvidTitleHolder), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new LightstoneAutoResponse().DefaultLightstoneResponse(), Guid.NewGuid(),
                DataProviderName.LightstoneAuto, DataProviderName.LightstoneAuto.ToString(), 0m,
                typeof (IProvideDataFromLightstoneAuto), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new RgtResponse(), Guid.NewGuid(), DataProviderName.Rgt,
                DataProviderName.Rgt.ToString(), 0m, typeof(IProvideDataFromRgt), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new RgtVinResponse(), Guid.NewGuid(), DataProviderName.RgtVin,
                DataProviderName.RgtVin.ToString(), 0m, typeof(IProvideDataFromRgtVin), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(new AudatexResponse().DefaultAudatexResponse(), Guid.NewGuid(), DataProviderName.Audatex,
                DataProviderName.Audatex.ToString(), 0m, typeof(IProvideDataFromAudatex), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(new PCubedFicaVerficationResponse(), Guid.NewGuid(),
                DataProviderName.PCubedFica,
                DataProviderName.PCubedFica.ToString(), 0m, typeof(IProvideDataFromPCubedFicaVerfication), "Owner",
                DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(new SignioDriversLicenseDecryptionResponse().DefaultSignioDriversLicenseDecryptionResponse(), Guid.NewGuid(),
                DataProviderName.SignioDecryptDriversLicense, DataProviderName.SignioDecryptDriversLicense.ToString(),
                0m, typeof(IProvideDataFromSignioDriversLicenseDecryption), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(new LightstonePropertyResponse().DefaultLightstonePropertyResponse(), Guid.NewGuid(),
                DataProviderName.LightstoneProperty, DataProviderName.LightstoneProperty.ToString(), 0m,
                typeof (IProvideDataFromLightstoneProperty), "Owner", DateTime.UtcNow));

            //_publisher.Publish(new CreateDataProvider(DefaultLightstoneBusinessResponse(), Guid.NewGuid(),
            //    DataProviderName.LightstoneBusiness, DataProviderName.LightstoneBusiness.ToString(), 0d,
            //    typeof(IProvideDataFromLightstoneBusiness), "Owner", DateTime.UtcNow));

            this.Info(() => "Successfully imported data providers");
        }
    }
}