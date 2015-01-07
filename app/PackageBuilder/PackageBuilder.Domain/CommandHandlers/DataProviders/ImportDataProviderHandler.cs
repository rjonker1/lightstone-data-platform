using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.DataProviders.Commands;

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
            this.Info(() => "Attempting to import data providers");

            _handler.Handle(new CreateDataProvider(DefaultIvidResponse(), Guid.NewGuid(), DataProviderName.Ivid, DataProviderName.Ivid.ToString(), 0d, typeof(IProvideDataFromIvid), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(new IvidTitleHolderResponse(), Guid.NewGuid(), DataProviderName.IvidTitleHolder, DataProviderName.IvidTitleHolder.ToString(), 0d, typeof(IProvideDataFromIvidTitleHolder), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(DefaultLightstoneResponse(), Guid.NewGuid(), DataProviderName.Lightstone, DataProviderName.Lightstone.ToString(), 0d, typeof(IProvideDataFromLightstone), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(new RgtResponse(), Guid.NewGuid(), DataProviderName.Rgt, DataProviderName.Rgt.ToString(), 0d, typeof(IProvideDataFromRgt), "Owner", DateTime.Now));
            _handler.Handle(new CreateDataProvider(new RgtVinResponse(), Guid.NewGuid(), DataProviderName.RgtVin, DataProviderName.RgtVin.ToString(), 0d, typeof(IProvideDataFromRgtVin), "Owner", DateTime.Now));

            this.Info(() => "Successfully imported data providers");
        }

        private static IvidResponse DefaultIvidResponse()
        {
            var ivid = new IvidResponse();
            ivid.BuildSpecificInformation();
            return ivid;
        }

        private LightstoneResponse DefaultLightstoneResponse()
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
            vehicleValuation.AddEstimatedValue(new[] { new EstimatedValueModel("", "", "", "", "") });
            vehicleValuation.AddLastFiveSales(new[] { new SaleModel("", "", "") });
            return new LightstoneResponse(0, 0, "", "", "", "", "", vehicleValuation);
        }
    }
}