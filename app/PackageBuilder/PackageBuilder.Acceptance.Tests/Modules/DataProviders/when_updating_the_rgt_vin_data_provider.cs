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

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_rgt_vin_data_provider : BaseDataProviderTest
    {
        public when_updating_the_rgt_vin_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSAutoVINMaster_I_DB, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.RgtVin);
                });
            });

            DataProvider = WriteRepo.GetById(Id);
        }

        public override void Observe()
        {

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
            DataProvider.Name.ShouldEqual(DataProviderName.LSAutoVINMaster_I_DB);
            DataProvider.Description.ShouldEqual("RgtVin");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(1);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(11);
        }

        [Observation]
        public void should_update_request_field_vin_number()
        {
            DataFieldExtensions.AssertRequestField("VinNumber", RequestFieldType.VinNumber, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_data_field_vin()
        {
            DataFieldExtensions.AssertDataField("Vin", "Vin Definition", "Vin Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_make()
        {
            DataFieldExtensions.AssertDataField("VehicleMake", "VehicleMake Definition", "VehicleMake Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_type()
        {
            DataFieldExtensions.AssertDataField("VehicleType", "VehicleType Definition", "VehicleType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_model()
        {
            DataFieldExtensions.AssertDataField("VehicleModel", "VehicleModel Definition", "VehicleModel Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_year()
        {
            DataFieldExtensions.AssertDataField("Year", "Year Definition", "Year Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_month()
        {
            DataFieldExtensions.AssertDataField("Month", "Month Definition", "Month Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_quarter()
        {
            DataFieldExtensions.AssertDataField("Quarter", "Quarter Definition", "Quarter Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_rgt_code()
        {
            DataFieldExtensions.AssertDataField("RgtCode", "RgtCode Definition", "RgtCode Label", 10, true, 0, typeof(int?));
        }

        [Observation]
        public void should_update_data_field_price()
        {
            DataFieldExtensions.AssertDataField("Price", "Price Definition", "Price Label", 10, true, 0, typeof(decimal?));
        }

        [Observation]
        public void should_update_data_field_colour()
        {
            DataFieldExtensions.AssertDataField("Colour", "Colour Definition", "Colour Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_car_full_name()
        {
            DataFieldExtensions.AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }
    }
}