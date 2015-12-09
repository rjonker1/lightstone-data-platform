using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Bases;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Api.Modules.DataProviders
{
    public class when_updating_the_lightstone_data_provider : BaseDataProviderTest
    {
        public when_updating_the_lightstone_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSAutoCarStats_I_DB, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.LightstoneAuto);
                });
            });
        }

        public override void Observe()
        {
            DataProvider = WriteRepo.GetById(Id);
        }

        [Observation]
        public void should_return_success_response()
        {
            Response.Body.AsString().ShouldNotBeNull();
            Response.Body.AsString().ShouldContain("Success");
        }

        [Observation]
        public void should_update_root_properties()
        {
            DataProvider.Name.ShouldEqual(DataProviderName.LSAutoCarStats_I_DB);
            DataProvider.Description.ShouldEqual("Lightstone Auto");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(4);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(8);
        }

        [Observation]
        public void should_update_request_field_car_id()
        {
            DataFieldExtensions.AssertRequestField("CarId", RequestFieldType.CarId, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_year()
        {
            DataFieldExtensions.AssertRequestField("Year", RequestFieldType.Year, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_make()
        {
            DataFieldExtensions.AssertRequestField("Make", RequestFieldType.Make, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_request_field_vin()
        {
            DataFieldExtensions.AssertRequestField("VinNumber", RequestFieldType.VinNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_data_field_car_id()
        {
            DataFieldExtensions.AssertDataField("CarId", "CarId Definition", "CarId Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_year()
        {
            DataFieldExtensions.AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_vin()
        {
            DataFieldExtensions.AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_image_url()
        {
            DataFieldExtensions.AssertDataField("ImageUrl", "ImageUrl Definition", "ImageUrl Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_quarter()
        {
            DataFieldExtensions.AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_CarFullname()
        {
            DataFieldExtensions.AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model()
        {
            DataFieldExtensions.AssertDataField("Model", "Model Definition", "Model Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_valuation()
        {
            DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
        }

        [Observation]
        public void should_update_data_field_estimated_value()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var estimatedValue = DataFieldExtensions.AssertDataField("EstimatedValue", "EstimatedValue Definition", "EstimatedValue Label", 10, true, 0, typeof(string), 0, 10, valuation.DataFields);

            DataFieldExtensions.AssertDataField("RetailEstimatedValue", "RetailEstimatedValue Definition", "RetailEstimatedValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("RetailEstimatedLow", "RetailEstimatedLow Definition", "RetailEstimatedLow Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("RetailEstimatedHigh", "RetailEstimatedHigh Definition", "RetailEstimatedHigh Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("RetailConfidenceValue", "RetailConfidenceValue Definition", "RetailConfidenceValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("RetailConfidenceLevel", "RetailConfidenceLevel Definition", "RetailConfidenceLevel Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("TradeEstimatedValue", "TradeEstimatedValue Definition", "TradeEstimatedValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("TradeEstimatedLow", "TradeEstimatedLow Definition", "TradeEstimatedLow Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("TradeEstimatedHigh", "TradeEstimatedHigh Definition", "TradeEstimatedHigh Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("TradeConfidenceValue", "TradeConfidenceValue Definition", "TradeConfidenceValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            DataFieldExtensions.AssertDataField("TradeConfidenceLevel", "TradeConfidenceLevel Definition", "TradeConfidenceLevel Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
        }

        [Observation]
        public void should_update_data_field_last_five_sales()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var lastFiveSales = DataFieldExtensions.AssertDataField("LastFiveSales", "LastFiveSales Definition", "LastFiveSales Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            DataFieldExtensions.AssertDataField("SalesDate", "SalesDate Definition", "SalesDate Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
            DataFieldExtensions.AssertDataField("LicensingDistrict", "LicensingDistrict Definition", "LicensingDistrict Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
            DataFieldExtensions.AssertDataField("SalesPrice", "SalesPrice Definition", "SalesPrice Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
        }

        [Observation]
        public void should_update_data_field_prices()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var prices = DataFieldExtensions.AssertDataField("Prices", "Prices Definition", "Prices Label", 10, true, 0, typeof(string), 0, 2, valuation.DataFields);

            DataFieldExtensions.AssertDataField("Name", "Name Definition", "Name Label", 10, true, 0, typeof(string), 0, 0, prices.DataFields);
            DataFieldExtensions.AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(decimal), 0, 0, prices.DataFields);
        }

        [Observation]
        public void should_update_data_frequency()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var frequency = DataFieldExtensions.AssertDataField("Frequency", "Frequency Definition", "Frequency Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            DataFieldExtensions.AssertDataField("CarType", "CarType Definition", "CarType Label", 10, true, 0, typeof(string), 0, 0, frequency.DataFields);
            DataFieldExtensions.AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, frequency.DataFields);
            DataFieldExtensions.AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double), 0, 0, frequency.DataFields);
        }

        [Observation]
        public void should_update_data_confidence()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var confidence = DataFieldExtensions.AssertDataField("Confidence", "Confidence Definition", "Confidence Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            DataFieldExtensions.AssertDataField("CarType", "CarType Definition", "CarType Label", 10, true, 0, typeof(string), 0, 0, confidence.DataFields);
            DataFieldExtensions.AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, confidence.DataFields);
            DataFieldExtensions.AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double), 0, 0, confidence.DataFields);
        }

        [Observation]
        public void should_update_data_amortised_values()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var amortisedValues = DataFieldExtensions.AssertDataField("AmortisedValues", "AmortisedValues Definition", "AmortisedValues Label", 10, true, 0, typeof(string), 0, 2, valuation.DataFields);

            DataFieldExtensions.AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, amortisedValues.DataFields);
            DataFieldExtensions.AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(decimal), 0, 0, amortisedValues.DataFields);
        }

        [Observation]
        public void should_update_data_image_guages()
        {
            var valuation = DataFieldExtensions.AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var imageGuages = DataFieldExtensions.AssertDataField("ImageGauges", "ImageGauges Definition", "ImageGauges Label", 10, true, 0, typeof(string), 0, 5, valuation.DataFields);

            DataFieldExtensions.AssertDataField("MinValue", "MinValue Definition", "MinValue Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            DataFieldExtensions.AssertDataField("MaxValue", "MaxValue Definition", "MaxValue Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            DataFieldExtensions.AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            DataFieldExtensions.AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            DataFieldExtensions.AssertDataField("GaugeName", "GaugeName Definition", "GaugeName Label", 10, true, 0, typeof(string), 0, 0, imageGuages.DataFields);
        }
    }
}