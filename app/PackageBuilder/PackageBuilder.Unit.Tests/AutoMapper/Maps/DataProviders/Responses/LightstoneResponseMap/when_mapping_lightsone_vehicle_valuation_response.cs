using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap
{
    public class when_mapping_lightsone_vehicle_valuation_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IRespondWithValuation, DataField>(LightstoneResponseMother.Response.VehicleValuation);
        }

        [Observation]
        public void should_map_vehicle_valuation_data_fields()
        {
            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(7);

            #region Deprecated fields

            //dataFields.FirstOrDefault(x => x.Name == "AmortisationFactors").Name.ShouldEqual("AmortisationFactors");
            //dataFields.FirstOrDefault(x => x.Name == "AmortisationFactors").Type.ShouldEqual(typeof(List<IRespondWithAmortisationFactorModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "AreaFactors").Name.ShouldEqual("AreaFactors");
            //dataFields.FirstOrDefault(x => x.Name == "AreaFactors").Type.ShouldEqual(typeof(List<IRespondWithAreaFactorModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "AuctionFactors").Name.ShouldEqual("AuctionFactors");
            //dataFields.FirstOrDefault(x => x.Name == "AuctionFactors").Type.ShouldEqual(typeof(List<IRespondWithAuctionFactorModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "AccidentDistribution").Name.ShouldEqual("AccidentDistribution");
            //dataFields.FirstOrDefault(x => x.Name == "AccidentDistribution").Type.ShouldEqual(typeof(List<IRespondWithAccidentDistributionModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "RepairIndex").Name.ShouldEqual("RepairIndex");
            //dataFields.FirstOrDefault(x => x.Name == "RepairIndex").Type.ShouldEqual(typeof(List<IRespondWithRepairIndexModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "TotalSalesByAge").Name.ShouldEqual("TotalSalesByAge");
            //dataFields.FirstOrDefault(x => x.Name == "TotalSalesByAge").Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByAgeModel>).ToString());

            //dataFields.FirstOrDefault(x => x.Name == "TotalSalesByGender").Name.ShouldEqual("TotalSalesByGender");
            //dataFields.FirstOrDefault(x => x.Name == "TotalSalesByGender").Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByGenderModel>).ToString());

            #endregion

            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Name.ShouldEqual("EstimatedValue");
            dataFields.FirstOrDefault(x => x.Name == "EstimatedValue").Type.ShouldEqual(typeof(IRespondWithEstimatedValueModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "LastFiveSales").Name.ShouldEqual("LastFiveSales");
            dataFields.FirstOrDefault(x => x.Name == "LastFiveSales").Type.ShouldEqual(typeof(IRespondWithSaleModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Prices").Name.ShouldEqual("Prices");
            dataFields.FirstOrDefault(x => x.Name == "Prices").Type.ShouldEqual(typeof(IRespondWithPriceModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Frequency").Name.ShouldEqual("Frequency");
            dataFields.FirstOrDefault(x => x.Name == "Frequency").Type.ShouldEqual(typeof(IRespondWithFrequencyModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Confidence").Name.ShouldEqual("Confidence");
            dataFields.FirstOrDefault(x => x.Name == "Confidence").Type.ShouldEqual(typeof(IRespondWithConfidenceModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "AmortisedValues").Name.ShouldEqual("AmortisedValues");
            dataFields.FirstOrDefault(x => x.Name == "AmortisedValues").Type.ShouldEqual(typeof(IRespondWithAmortisedValueModel[]).ToString());

            dataFields.FirstOrDefault(x => x.Name == "ImageGauges").Name.ShouldEqual("ImageGauges");
            dataFields.FirstOrDefault(x => x.Name == "ImageGauges").Type.ShouldEqual(typeof(IRespondWithImageGaugeModel[]).ToString());
        }
    }
}