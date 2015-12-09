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
    public class when_updating_the_rgt_data_provider : BaseDataProviderTest
    {
        public when_updating_the_rgt_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.LSAutoSpecs_I_DB, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.Rgt);
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
            DataProvider.Name.ShouldEqual(DataProviderName.LSAutoSpecs_I_DB);
            DataProvider.Description.ShouldEqual("Rgt");
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
            DataProvider.DataFields.Count().ShouldEqual(21);
        }

        [Observation]
        public void should_update_request_field_vin_number()
        {
            DataFieldExtensions.AssertRequestField("CarId", RequestFieldType.CarId, DataProvider.RequestFields);
        }

        [Observation]
        public void should_update_data_field_manufacturer()
        {
            DataFieldExtensions.AssertDataField("Manufacturer", "Manufacturer Definition", "Manufacturer Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model_year()
        {
            DataFieldExtensions.AssertDataField("ModelYear", "ModelYear Definition", "ModelYear Label", 10, true, 0, typeof(int));
        }

        [Observation]
        public void should_update_data_field_model_type()
        {
            DataFieldExtensions.AssertDataField("ModelType", "ModelType Definition", "ModelType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_top_speed()
        {
            DataFieldExtensions.AssertDataField("TopSpeed", "TopSpeed Definition", "TopSpeed Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_kilowatts()
        {
            DataFieldExtensions.AssertDataField("Kilowatts", "Kilowatts Definition", "Kilowatts Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_fuel_economy()
        {
            DataFieldExtensions.AssertDataField("FuelEconomy", "FuelEconomy Definition", "FuelEconomy Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_acceleration()
        {
            DataFieldExtensions.AssertDataField("Acceleration", "Acceleration Definition", "Acceleration Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_torque()
        {
            DataFieldExtensions.AssertDataField("Torque", "Torque Definition", "Torque Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_emissions()
        {
            DataFieldExtensions.AssertDataField("Emissions", "Emissions Definition", "Emissions Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_engine_size()
        {
            DataFieldExtensions.AssertDataField("EngineSize", "EngineSize Definition", "EngineSize Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_body_shape()
        {
            DataFieldExtensions.AssertDataField("BodyShape", "BodyShape Definition", "BodyShape Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_fuel_type()
        {
            DataFieldExtensions.AssertDataField("FuelType", "FuelType Definition", "FuelType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_transmission_type()
        {
            DataFieldExtensions.AssertDataField("TransmissionType", "TransmissionType Definition", "TransmissionType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_car_full_name()
        {
            DataFieldExtensions.AssertDataField("CarFullname", "CarFullname Definition", "CarFullname Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_colour()
        {
            DataFieldExtensions.AssertDataField("Colour", "Colour Definition", "Colour Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_rain_sensor_windscreen_wipers()
        {
            DataFieldExtensions.AssertDataField("RainSensorWindscreenWipers", "RainSensorWindscreenWipers Definition", "RainSensorWindscreenWipers Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_head_up_display()
        {
            DataFieldExtensions.AssertDataField("HeadUpDisplay", "HeadUpDisplay Definition", "HeadUpDisplay Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_vehicle_type()
        {
            DataFieldExtensions.AssertDataField("VehicleType", "VehicleType Definition", "VehicleType Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_model()
        {
            DataFieldExtensions.AssertDataField("Model", "Model Definition", "Model Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_make()
        {
            DataFieldExtensions.AssertDataField("Make", "Make Definition", "Make Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_car_type()
        {
            DataFieldExtensions.AssertDataField("CarType", "CarType Definition", "CarType Label", 10, true, 0, typeof(string));
        }
    }
}