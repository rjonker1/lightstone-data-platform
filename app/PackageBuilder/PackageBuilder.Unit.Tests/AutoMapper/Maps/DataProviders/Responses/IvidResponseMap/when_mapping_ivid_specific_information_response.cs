﻿using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.Ivid;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.IvidResponseMap
{
    public class when_mapping_ivid_specific_information_response : BaseTestHelper
    {
        private readonly IDataField _dataField;

        public when_mapping_ivid_specific_information_response()
        {
            _dataField = Mapper.Map<IProvideVehicleSpecificInformation, DataField>(IvidResponseMother.Response.SpecificInformation);
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void should_map_specific_information_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(VehicleSpecificInformation).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(7);

            dataFields.FirstOrDefault(x => x.Name == "Odometer").Name.ShouldEqual("Odometer");
            dataFields.FirstOrDefault(x => x.Name == "Odometer").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Colour").Name.ShouldEqual("Colour");
            dataFields.FirstOrDefault(x => x.Name == "Colour").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "RegistrationNumber").Name.ShouldEqual("RegistrationNumber");
            dataFields.FirstOrDefault(x => x.Name == "RegistrationNumber").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "VinNumber").Name.ShouldEqual("VinNumber");
            dataFields.FirstOrDefault(x => x.Name == "VinNumber").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "LicenseNumber").Name.ShouldEqual("LicenseNumber");
            dataFields.FirstOrDefault(x => x.Name == "LicenseNumber").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "EngineNumber").Name.ShouldEqual("EngineNumber");
            dataFields.FirstOrDefault(x => x.Name == "EngineNumber").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Name.ShouldEqual("CategoryDescription");
            dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}