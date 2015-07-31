using System;
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
        private DataProvider _dataProvider;

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

        private IDataField GetRequestField(string name)
        {
            return _dataProvider.RequestFields.FirstOrDefault(x => x.Name == name);
        }

        private IDataField GetDataField(string name)
        {
            return _dataProvider.DataFields.FirstOrDefault(x => x.Name == name);
        }

        private void AssertDataField(string name, string definition, string label, double costOfSale, bool isSelected, int order, Type type)
        {
            var field = GetDataField(name);
            field.Definition.ShouldEqual(definition);
            field.Label.ShouldEqual(label);
            field.CostOfSale.ShouldEqual(costOfSale);
            field.IsSelected.ShouldEqual(isSelected);
            field.Namespace.ShouldBeNull();
            field.Order.ShouldEqual(order);
            field.Type.ShouldEqual(type.ToString());
            field.Value.ShouldBeNull();
            field.Industries.ShouldBeEmpty();
            field.DataFields.ShouldBeEmpty();
        }

        private void AssertRequestField(string name, RequestFieldType type)
        {
            var field = GetRequestField(name);
            field.ShouldNotBeNull();

            //todo: check type
            //field.Type.ShouldEqual(((int)type).ToString());
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

            //var field = GetDataField("CarId");
            //field.Definition.ShouldEqual("Definition");
            //field.Label.ShouldEqual("Car Id");
            //field.CostOfSale.ShouldEqual(10);
            //field.IsSelected.ShouldEqual(true);
            //field.Namespace.ShouldBeNull();
            //field.Order.ShouldEqual(0);
            //field.Type.ShouldEqual(typeof(int?).ToString());
            //field.Value.ShouldBeNull();
            //field.Industries.ShouldBeEmpty();
            //field.DataFields.ShouldBeEmpty();
        }

        [Observation]
        public void should_update_model_data_field_year()
        {
            AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_model_data_field_vin()
        {
            AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_model_data_field_image_url()
        {
            AssertDataField("ImageUrl", "ImageUrl Definition", "ImageUrl Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_model_data_field_quarter()
        {
            AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_model_data_field_CarFullname()
        {
            AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_model_data_field_model()
        {
            AssertDataField("Model", "Model Definition", "Model Label", 10, true, 0, typeof(string));
        }
    }
}