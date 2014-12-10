using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.IvidResponseMap
{
    public class when_mapping_ivid_specific_information_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IProvideVehicleSpecificInformation, IDataField>(IvidResponseMother.Response.SpecificInformation);
        }

        [Observation]
        public void should_map_specific_information_data_fields()
        {
            _dataField.Name.ShouldEqual("SpecificInformation");
            _dataField.Type.ShouldEqual(typeof(VehicleSpecificInformation));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(7);

            dataFields.FirstOrDefault(x => x.Name == "Odometer").Name.ShouldEqual("Odometer");
            dataFields.FirstOrDefault(x => x.Name == "Odometer").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Colour").Name.ShouldEqual("Colour");
            dataFields.FirstOrDefault(x => x.Name == "Colour").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "RegistrationNumber").Name.ShouldEqual("RegistrationNumber");
            dataFields.FirstOrDefault(x => x.Name == "RegistrationNumber").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "VinNumber").Name.ShouldEqual("VinNumber");
            dataFields.FirstOrDefault(x => x.Name == "VinNumber").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "LicenseNumber").Name.ShouldEqual("LicenseNumber");
            dataFields.FirstOrDefault(x => x.Name == "LicenseNumber").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "EngineNumber").Name.ShouldEqual("EngineNumber");
            dataFields.FirstOrDefault(x => x.Name == "EngineNumber").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Name.ShouldEqual("CategoryDescription");
            dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Type.ShouldEqual(typeof(string));
        }
    }
}