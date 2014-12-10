using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap
{
    public class when_mapping_lightsone_response : Specification
    {
        private IEnumerable<IDataField> _dataFields;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataFields = Mapper.Map<IProvideDataFromLightstone, IEnumerable<IDataField>>(LightstoneResponseMother.Response);
        }

        [Observation]
        public void should_map_all_lightstone_fields()
        {
            _dataFields.Count().ShouldEqual(8);

            _dataFields.FirstOrDefault(x => x.Name == "CarId").Name.ShouldEqual("CarId");
            _dataFields.FirstOrDefault(x => x.Name == "CarId").Type.ShouldEqual(typeof(int?));

            _dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int?));

            _dataFields.FirstOrDefault(x => x.Name == "Vin").Name.ShouldEqual("Vin");
            _dataFields.FirstOrDefault(x => x.Name == "Vin").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ImageUrl").Name.ShouldEqual("ImageUrl");
            _dataFields.FirstOrDefault(x => x.Name == "ImageUrl").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            _dataFields.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldEqual("CarFullname");
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Model").Name.ShouldEqual("Model");
            _dataFields.FirstOrDefault(x => x.Name == "Model").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "VehicleValuation").Name.ShouldEqual("VehicleValuation");
            _dataFields.FirstOrDefault(x => x.Name == "VehicleValuation").Type.ShouldEqual(typeof(Valuation));
        }
    }
}