using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap
{
    public class when_mapping_lightsone_vehicle_valuation_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithValuation, IDataField>(LightstoneResponseMother.Response.VehicleValuation);
        }

        [Observation]
        public void should_map_vehicle_valuation_data_fields()
        {
            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(14);

            dataFields.FirstOrDefault(x => x.Name == "AmortisationFactors").Name.ShouldEqual("AmortisationFactors");
            dataFields.FirstOrDefault(x => x.Name == "AmortisationFactors").Type.ShouldEqual(typeof(List<IRespondWithAmortisationFactorModel>));

            dataFields.FirstOrDefault(x => x.Name == "AreaFactors").Name.ShouldEqual("AreaFactors");
            dataFields.FirstOrDefault(x => x.Name == "AreaFactors").Type.ShouldEqual(typeof(List<IRespondWithAreaFactorModel>));

            dataFields.FirstOrDefault(x => x.Name == "AuctionFactors").Name.ShouldEqual("AuctionFactors");
            dataFields.FirstOrDefault(x => x.Name == "AuctionFactors").Type.ShouldEqual(typeof(List<IRespondWithAuctionFactorModel>));

            dataFields.FirstOrDefault(x => x.Name == "AccidentDistribution").Name.ShouldEqual("AccidentDistribution");
            dataFields.FirstOrDefault(x => x.Name == "AccidentDistribution").Type.ShouldEqual(typeof(List<IRespondWithAccidentDistributionModel>));

            dataFields.FirstOrDefault(x => x.Name == "RepairIndex").Name.ShouldEqual("RepairIndex");
            dataFields.FirstOrDefault(x => x.Name == "RepairIndex").Type.ShouldEqual(typeof(List<IRespondWithRepairIndexModel>));

            dataFields.FirstOrDefault(x => x.Name == "TotalSalesByAge").Name.ShouldEqual("TotalSalesByAge");
            dataFields.FirstOrDefault(x => x.Name == "TotalSalesByAge").Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByAgeModel>));

            dataFields.FirstOrDefault(x => x.Name == "TotalSalesByGender").Name.ShouldEqual("TotalSalesByGender");
            dataFields.FirstOrDefault(x => x.Name == "TotalSalesByGender").Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByGenderModel>));

            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Name.ShouldEqual("EstimatedValue");
            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Type.ShouldEqual(typeof(List<IRespondWithEstimatedValueModel>));

            dataFields.FirstOrDefault(x => x.Name == "LastFiveSales").Name.ShouldEqual("LastFiveSales");
            dataFields.FirstOrDefault(x => x.Name == "LastFiveSales").Type.ShouldEqual(typeof(List<IRespondWithSaleModel>));

            dataFields.FirstOrDefault(x => x.Name == "Prices").Name.ShouldEqual("Prices");
            dataFields.FirstOrDefault(x => x.Name == "Prices").Type.ShouldEqual(typeof(List<IRespondWithPriceModel>));

            dataFields.FirstOrDefault(x => x.Name == "Frequency").Name.ShouldEqual("Frequency");
            dataFields.FirstOrDefault(x => x.Name == "Frequency").Type.ShouldEqual(typeof(List<IRespondWithFrequencyModel>));

            dataFields.FirstOrDefault(x => x.Name == "Confidence").Name.ShouldEqual("Confidence");
            dataFields.FirstOrDefault(x => x.Name == "Confidence").Type.ShouldEqual(typeof(List<IRespondWithConfidenceModel>));

            dataFields.FirstOrDefault(x => x.Name == "AmortisedValues").Name.ShouldEqual("AmortisedValues");
            dataFields.FirstOrDefault(x => x.Name == "AmortisedValues").Type.ShouldEqual(typeof(List<IRespondWithAmortisedValueModel>));

            dataFields.FirstOrDefault(x => x.Name == "ImageGauges").Name.ShouldEqual("ImageGauges");
            dataFields.FirstOrDefault(x => x.Name == "ImageGauges").Type.ShouldEqual(typeof(List<IRespondWithImageGaugeModel>));
        }
    }
}