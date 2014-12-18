using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_rgt_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;

        public override void Observe()
        {
            base.Observe();

            _dataFields = Mapper.Map<IProvideDataFromRgt, IEnumerable<IDataField>>(RgtResponseMother.Response);
        }

        [Observation]
        public void should_map_all_rgt_data_fields()
        {
            _dataFields.Count().ShouldEqual(21);

            _dataFields.FirstOrDefault(x => x.Name == "Manufacturer").Name.ShouldEqual("Manufacturer");
            _dataFields.FirstOrDefault(x => x.Name == "Manufacturer").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ModelYear").Name.ShouldEqual("ModelYear");
            _dataFields.FirstOrDefault(x => x.Name == "ModelYear").Type.ShouldEqual(typeof(int));

            _dataFields.FirstOrDefault(x => x.Name == "ModelType").Name.ShouldEqual("ModelType");
            _dataFields.FirstOrDefault(x => x.Name == "ModelType").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "TopSpeed").Name.ShouldEqual("TopSpeed");
            _dataFields.FirstOrDefault(x => x.Name == "TopSpeed").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Kilowatts").Name.ShouldEqual("Kilowatts");
            _dataFields.FirstOrDefault(x => x.Name == "Kilowatts").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "FuelEconomy").Name.ShouldEqual("FuelEconomy");
            _dataFields.FirstOrDefault(x => x.Name == "FuelEconomy").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Acceleration").Name.ShouldEqual("Acceleration");
            _dataFields.FirstOrDefault(x => x.Name == "Acceleration").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Torque").Name.ShouldEqual("Torque");
            _dataFields.FirstOrDefault(x => x.Name == "Torque").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Emissions").Name.ShouldEqual("Emissions");
            _dataFields.FirstOrDefault(x => x.Name == "Emissions").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "EngineSize").Name.ShouldEqual("EngineSize");
            _dataFields.FirstOrDefault(x => x.Name == "EngineSize").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "BodyShape").Name.ShouldEqual("BodyShape");
            _dataFields.FirstOrDefault(x => x.Name == "BodyShape").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "FuelType").Name.ShouldEqual("FuelType");
            _dataFields.FirstOrDefault(x => x.Name == "FuelType").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldEqual("CarFullname");
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Colour").Name.ShouldEqual("Colour");
            _dataFields.FirstOrDefault(x => x.Name == "Colour").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "RainSensorWindscreenWipers").Name.ShouldEqual("RainSensorWindscreenWipers");
            _dataFields.FirstOrDefault(x => x.Name == "RainSensorWindscreenWipers").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "HeadUpDisplay").Name.ShouldEqual("HeadUpDisplay");
            _dataFields.FirstOrDefault(x => x.Name == "HeadUpDisplay").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "VehicleType").Name.ShouldEqual("VehicleType");
            _dataFields.FirstOrDefault(x => x.Name == "VehicleType").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Model").Name.ShouldEqual("Model");
            _dataFields.FirstOrDefault(x => x.Name == "Model").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Make").Name.ShouldEqual("Make");
            _dataFields.FirstOrDefault(x => x.Name == "Make").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            _dataFields.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string));

        }
    }
}