using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_lightStone_data_provider : MemoryTestDataBaseHelper
    {
        private Guid _id = Guid.NewGuid();
        private readonly Browser _browser = new Browser(new TestBootstrapper());
        private BrowserResponse _response;
        private INEventStoreRepository<DataProvider> _writeRepo;
        private IHandleMessages _handler;
        private readonly DataProvider _dataProvider;

        public when_updating_the_lightStone_data_provider()
        {
            RefreshDb();

            Container.Install(new WindsorInstaller());

            _writeRepo = Container.Resolve<INEventStoreRepository<DataProvider>>();
            _handler = Container.Resolve<IHandleMessages>();
            _handler.Handle(new CreateDataProvider(_id, DataProviderName.LightstoneAuto, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                _response = _browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", _id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.LightstoneAuto);
                });
            });

            _dataProvider = _writeRepo.GetById(_id);
        }

        public override void Observe()
        {
            
        }

        private void AssertRequestField(string name, RequestFieldType type)
        {
            var field = _dataProvider.RequestFields.Get(name);
            field.ShouldNotBeNull();

            //todo: check type
            //field.Type.ShouldEqual(((int)type).ToString());
        }

        private IDataField AssertDataField(string name, string definition, string label, double costOfSale, bool isSelected, int order, Type type, int industryCount = 0, int dataFieldCount = 0, IEnumerable<IDataField> dataFields = null)
        {
            dataFields = dataFields ?? _dataProvider.DataFields;
            var field = dataFields.Get(name);
            field.Definition.ShouldEqual(definition);
            field.Label.ShouldEqual(label);
            field.CostOfSale.ShouldEqual(costOfSale);
            field.IsSelected.ShouldEqual(isSelected);
            field.Namespace.ShouldBeNull();
            field.Order.ShouldEqual(order);
            field.Type.ShouldEqual(type.ToString());
            field.Value.ShouldBeNull();
            field.Industries.Count().ShouldEqual(industryCount);
            field.DataFields.Count().ShouldEqual(dataFieldCount);
            return field;
        }

        [Observation]
        public void should_return_success_response()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Success");
        }

        [Observation]
        public void should_update_root_properties()
        {
            _dataProvider.Name.ShouldEqual(DataProviderName.LightstoneAuto);
            _dataProvider.Description.ShouldEqual("Lightstone Auto");
            _dataProvider.CreatedDate.Date.ShouldEqual(DateTime.Now.Date);
            _dataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.Now.Date);
            _dataProvider.Owner.ShouldEqual("Owner");
            _dataProvider.Version.ShouldEqual(2);
            _dataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            _dataProvider.RequestFields.Count().ShouldEqual(4);
        }

        [Observation]
        public void should_update_request_field_car_id()
        {
            AssertRequestField("CarId", RequestFieldType.CarId);
        }

        [Observation]
        public void should_update_request_field_year()
        {
            AssertRequestField("Year", RequestFieldType.Year);
        }

        [Observation]
        public void should_update_request_field_make()
        {
            AssertRequestField("Make", RequestFieldType.Make);
        }

        [Observation]
        public void should_update_request_field_vin()
        {
            AssertRequestField("VinNumber", RequestFieldType.VinNumber);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            _dataProvider.DataFields.Count().ShouldEqual(8);
        }

        [Observation]
        public void should_update_data_field_car_id()
        {
            AssertDataField("CarId", "CarId Definition", "CarId Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_year()
        {
            AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_vin()
        {
            AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_image_url()
        {
            AssertDataField("ImageUrl", "ImageUrl Definition", "ImageUrl Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_quarter()
        {
            AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_CarFullname()
        {
            AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model()
        {
            AssertDataField("Model", "Model Definition", "Model Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_valuation()
        {
            AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
        }

        [Observation]
        public void should_update_data_field_estimated_value()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var estimatedValue = AssertDataField("EstimatedValue", "EstimatedValue Definition", "EstimatedValue Label", 10, true, 0, typeof(string), 0, 10, valuation.DataFields);

            AssertDataField("RetailEstimatedValue", "RetailEstimatedValue Definition", "RetailEstimatedValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("RetailEstimatedLow", "RetailEstimatedLow Definition", "RetailEstimatedLow Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("RetailEstimatedHigh", "RetailEstimatedHigh Definition", "RetailEstimatedHigh Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("RetailConfidenceValue", "RetailConfidenceValue Definition", "RetailConfidenceValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("RetailConfidenceLevel", "RetailConfidenceLevel Definition", "RetailConfidenceLevel Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("TradeEstimatedValue", "TradeEstimatedValue Definition", "TradeEstimatedValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("TradeEstimatedLow", "TradeEstimatedLow Definition", "TradeEstimatedLow Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("TradeEstimatedHigh", "TradeEstimatedHigh Definition", "TradeEstimatedHigh Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("TradeConfidenceValue", "TradeConfidenceValue Definition", "TradeConfidenceValue Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
            AssertDataField("TradeConfidenceLevel", "TradeConfidenceLevel Definition", "TradeConfidenceLevel Label", 10, true, 0, typeof(string), 0, 0, estimatedValue.DataFields);
        }

        [Observation]
        public void should_update_data_field_last_five_sales()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var lastFiveSales = AssertDataField("LastFiveSales", "LastFiveSales Definition", "LastFiveSales Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            AssertDataField("SalesDate", "SalesDate Definition", "SalesDate Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
            AssertDataField("LicensingDistrict", "LicensingDistrict Definition", "LicensingDistrict Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
            AssertDataField("SalesPrice", "SalesPrice Definition", "SalesPrice Label", 10, true, 0, typeof(string), 0, 0, lastFiveSales.DataFields);
        }

        [Observation]
        public void should_update_data_field_prices()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var prices = AssertDataField("Prices", "Prices Definition", "Prices Label", 10, true, 0, typeof(string), 0, 2, valuation.DataFields);

            AssertDataField("Name", "Name Definition", "Name Label", 10, true, 0, typeof(string), 0, 0, prices.DataFields);
            AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(decimal), 0, 0, prices.DataFields);
        }

        [Observation]
        public void should_update_data_frequency()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var frequency = AssertDataField("Frequency", "Frequency Definition", "Frequency Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            AssertDataField("CarType", "CarType Definition", "CarType Label", 10, true, 0, typeof(string), 0, 0, frequency.DataFields);
            AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, frequency.DataFields);
            AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double), 0, 0, frequency.DataFields);
        }

        [Observation]
        public void should_update_data_confidence()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var confidence = AssertDataField("Confidence", "Confidence Definition", "Confidence Label", 10, true, 0, typeof(string), 0, 3, valuation.DataFields);

            AssertDataField("CarType", "CarType Definition", "CarType Label", 10, true, 0, typeof(string), 0, 0, confidence.DataFields);
            AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, confidence.DataFields);
            AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double), 0, 0, confidence.DataFields);
        }

        [Observation]
        public void should_update_data_amortised_values()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var amortisedValues = AssertDataField("AmortisedValues", "AmortisedValues Definition", "AmortisedValues Label", 10, true, 0, typeof(string), 0, 2, valuation.DataFields);

            AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?), 0, 0, amortisedValues.DataFields);
            AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(decimal), 0, 0, amortisedValues.DataFields);
        }

        [Observation]
        public void should_update_data_image_guages()
        {
            var valuation = AssertDataField("VehicleValuation", "VehicleValuation Definition", "VehicleValuation Label", 10, true, 0, typeof(string), 0, 7);
            var imageGuages = AssertDataField("ImageGauges", "ImageGauges Definition", "ImageGauges Label", 10, true, 0, typeof(string), 0, 5, valuation.DataFields);

            AssertDataField("MinValue", "MinValue Definition", "MinValue Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            AssertDataField("MaxValue", "MaxValue Definition", "MaxValue Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            AssertDataField("Value", "Value Definition", "Value Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(double?), 0, 0, imageGuages.DataFields);
            AssertDataField("GaugeName", "GaugeName Definition", "GaugeName Label", 10, true, 0, typeof(string), 0, 0, imageGuages.DataFields);
        }
    }
}