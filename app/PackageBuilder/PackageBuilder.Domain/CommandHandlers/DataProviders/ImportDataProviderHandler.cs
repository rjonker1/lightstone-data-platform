using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;

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

            _publisher.Publish(new CreateDataProvider(DefaultIvidResponse(), Guid.NewGuid(), DataProviderName.Ivid,
                DataProviderName.Ivid.ToString(), 0m, typeof (IProvideDataFromIvid), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new IvidTitleHolderResponse(), Guid.NewGuid(),
                DataProviderName.IvidTitleHolder, DataProviderName.IvidTitleHolder.ToString(), 0m,
                typeof (IProvideDataFromIvidTitleHolder), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(DefaultLightstoneResponse(), Guid.NewGuid(),
                DataProviderName.LightstoneAuto, DataProviderName.LightstoneAuto.ToString(), 0m,
                typeof (IProvideDataFromLightstoneAuto), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new RgtResponse(), Guid.NewGuid(), DataProviderName.Rgt,
                DataProviderName.Rgt.ToString(), 0m, typeof(IProvideDataFromRgt), "Owner", DateTime.UtcNow));
            _publisher.Publish(new CreateDataProvider(new RgtVinResponse(), Guid.NewGuid(), DataProviderName.RgtVin,
                DataProviderName.RgtVin.ToString(), 0m, typeof(IProvideDataFromRgtVin), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(DefaultAudatexResponse(), Guid.NewGuid(), DataProviderName.Audatex,
                DataProviderName.Audatex.ToString(), 0m, typeof(IProvideDataFromAudatex), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(new PCubedFicaVerficationResponse(), Guid.NewGuid(),
                DataProviderName.PCubedFica,
                DataProviderName.PCubedFica.ToString(), 0m, typeof(IProvideDataFromPCubedFicaVerfication), "Owner",
                DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(DefaultSignioDriversLicenseDecryptionResponse(), Guid.NewGuid(),
                DataProviderName.SignioDecryptDriversLicense, DataProviderName.SignioDecryptDriversLicense.ToString(),
                0m, typeof(IProvideDataFromSignioDriversLicenseDecryption), "Owner", DateTime.UtcNow));

            _publisher.Publish(new CreateDataProvider(DefaultLightstonePropertyResponse(), Guid.NewGuid(),
                DataProviderName.LightstoneProperty, DataProviderName.LightstoneProperty.ToString(), 0m,
                typeof (IProvideDataFromLightstoneProperty), "Owner", DateTime.UtcNow));

            //_publisher.Publish(new CreateDataProvider(DefaultLightstoneBusinessResponse(), Guid.NewGuid(),
            //    DataProviderName.LightstoneBusiness, DataProviderName.LightstoneBusiness.ToString(), 0d,
            //    typeof(IProvideDataFromLightstoneBusiness), "Owner", DateTime.UtcNow));

            this.Info(() => "Successfully imported data providers");
        }

        private static LightstonePropertyResponse DefaultLightstonePropertyResponse()
        {
            return new LightstonePropertyResponse(new List<IRespondWithProperty>()
            {
                new PropertyModel(0, 0M, 0M, 0M, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, 0, 0M, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, 0M, 0M, string.Empty, string.Empty, string.Empty,
                    Guid.Empty, 0, string.Empty, 0, 0, 0D, 0D, 0D, string.Empty, string.Empty, string.Empty,
                    string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, 0, 0M, string.Empty, string.Empty, 0,
                    0, false)
            });
        }

        private static LightstoneBusinessResponse DefaultLightstoneBusinessResponse()
        {

            var result  = new List<IRespondWithBusiness>(); // List<ReturnCompaniesResponse.Company>();
            
            return new LightstoneBusinessResponse(result)
            {
                // TODO: new up a company response
            };
        }

        private static AudatexResponse DefaultAudatexResponse()
        {
            return
                new AudatexResponse(new List<IProvideAccidentClaim>()
                {
                    new AccidentClaim(DateTime.MinValue, string.Empty, string.Empty, DateTime.MinValue, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        0.0M, 0.0M, DateTime.MinValue, string.Empty, string.Empty, string.Empty, string.Empty)
                });
        }

        private static IvidResponse DefaultIvidResponse()
        {
            var ivid = new IvidResponse();
            ivid.BuildSpecificInformation();
            return ivid;
        }

        private static SignioDriversLicenseDecryptionResponse DefaultSignioDriversLicenseDecryptionResponse()
        {
            return
                new SignioDriversLicenseDecryptionResponse(
                    new DrivingLicenseCard(new IdentityDocument(), new Person(), new DrivingLicense(), new Card(),
                        new ProfessionalDrivingPermit(), new VehicleClass(), new VehicleClass(), new VehicleClass(),
                        new VehicleClass(), string.Empty, string.Empty, string.Empty), string.Empty);
        }

        private LightstoneAutoResponse DefaultLightstoneResponse()
        {
            var vehicleValuation = new Valuation();
            vehicleValuation.AddAmortisationFactors(new[] { new AmortisationFactorModel(0, 0d) });
            vehicleValuation.AddAreaFactors(new[] { new AreaFactorModel("", 0d) });
            vehicleValuation.AddAuctionFactors(new[] { new AuctionFactorModel("", 0m) });
            vehicleValuation.AddAccidentDistribution(new[] { new AccidentDistributionModel("", 0d) });
            vehicleValuation.AddRepairIndex(new[] { new RepairIndexModel(0, "", 0d) });
            vehicleValuation.AddTotalSalesByAge(new[] { new TotalSalesByAgeModel() });
            vehicleValuation.AddTotalSalesByGender(new[] { new TotalSalesByGenderModel("", "", 0d) });
            vehicleValuation.AddPrices(new[] { new PriceModel("", 0m) });
            vehicleValuation.AddFrequency(new[] { new FrequencyModel("", 0, 0d) });
            vehicleValuation.AddConfidence(new[] { new ConfidenceModel("", 0, 0d) });
            vehicleValuation.AddAmortisedValues(new[] { new AmortisedValueModel("", 0m) });
            vehicleValuation.AddImageGauages(new[] { new ImageGaugeModel(null, null, null, null, "") });
            vehicleValuation.AddEstimatedValue(new[] { new EstimatedValueModel() });
            vehicleValuation.AddLastFiveSales(new[] { new SaleModel("", "", "") });
            return new LightstoneAutoResponse(0, 0, "", "", "", "", "", vehicleValuation);
        }
    }
}