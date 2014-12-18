using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviderResponses.IvidResponseMap
{
    public class when_mapping_ivid_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            _dataFields = Mapper.Map<IProvideDataFromIvid, IEnumerable<IDataField>>(IvidResponseMother.Response);
        }

        [Observation]
        public void should_map_all_ivid_data_fields()
        {
            _dataFields.Count().ShouldEqual(31);

            _dataFields.FirstOrDefault(x => x.Name == "SpecificInformation").Name.ShouldEqual("SpecificInformation");
            _dataFields.FirstOrDefault(x => x.Name == "SpecificInformation").Type.ShouldEqual(typeof(VehicleSpecificInformation));

            _dataFields.FirstOrDefault(x => x.Name == "StatusMessage").Name.ShouldEqual("StatusMessage");
            _dataFields.FirstOrDefault(x => x.Name == "StatusMessage").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Reference").Name.ShouldEqual("Reference");
            _dataFields.FirstOrDefault(x => x.Name == "Reference").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "License").Name.ShouldEqual("License");
            _dataFields.FirstOrDefault(x => x.Name == "License").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Registration").Name.ShouldEqual("Registration");
            _dataFields.FirstOrDefault(x => x.Name == "Registration").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "RegistrationDate").Name.ShouldEqual("RegistrationDate");
            _dataFields.FirstOrDefault(x => x.Name == "RegistrationDate").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Vin").Name.ShouldEqual("Vin");
            _dataFields.FirstOrDefault(x => x.Name == "Vin").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Engine").Name.ShouldEqual("Engine");
            _dataFields.FirstOrDefault(x => x.Name == "Engine").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Displacement").Name.ShouldEqual("Displacement");
            _dataFields.FirstOrDefault(x => x.Name == "Displacement").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Tare").Name.ShouldEqual("Tare");
            _dataFields.FirstOrDefault(x => x.Name == "Tare").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "MakeCode").Name.ShouldEqual("MakeCode");
            _dataFields.FirstOrDefault(x => x.Name == "MakeCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "MakeDescription").Name.ShouldEqual("MakeDescription");
            _dataFields.FirstOrDefault(x => x.Name == "MakeDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ModelCode").Name.ShouldEqual("ModelCode");
            _dataFields.FirstOrDefault(x => x.Name == "ModelCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ModelDescription").Name.ShouldEqual("ModelDescription");
            _dataFields.FirstOrDefault(x => x.Name == "ModelDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ColourCode").Name.ShouldEqual("ColourCode");
            _dataFields.FirstOrDefault(x => x.Name == "ColourCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "ColourDescription").Name.ShouldEqual("ColourDescription");
            _dataFields.FirstOrDefault(x => x.Name == "ColourDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "DrivenCode").Name.ShouldEqual("DrivenCode");
            _dataFields.FirstOrDefault(x => x.Name == "DrivenCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "DrivenDescription").Name.ShouldEqual("DrivenDescription");
            _dataFields.FirstOrDefault(x => x.Name == "DrivenDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "CategoryCode").Name.ShouldEqual("CategoryCode");
            _dataFields.FirstOrDefault(x => x.Name == "CategoryCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Name.ShouldEqual("CategoryDescription");
            _dataFields.FirstOrDefault(x => x.Name == "CategoryDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "DescriptionCode").Name.ShouldEqual("DescriptionCode");
            _dataFields.FirstOrDefault(x => x.Name == "DescriptionCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "Description").Name.ShouldEqual("Description");
            _dataFields.FirstOrDefault(x => x.Name == "Description").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "EconomicSectorCode").Name.ShouldEqual("EconomicSectorCode");
            _dataFields.FirstOrDefault(x => x.Name == "EconomicSectorCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "EconomicSectorDescription").Name.ShouldEqual("EconomicSectorDescription");
            _dataFields.FirstOrDefault(x => x.Name == "EconomicSectorDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "LifeStatusCode").Name.ShouldEqual("LifeStatusCode");
            _dataFields.FirstOrDefault(x => x.Name == "LifeStatusCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "LifeStatusDescription").Name.ShouldEqual("LifeStatusDescription");
            _dataFields.FirstOrDefault(x => x.Name == "LifeStatusDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "SapMarkCode").Name.ShouldEqual("SapMarkCode");
            _dataFields.FirstOrDefault(x => x.Name == "SapMarkCode").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "SapMarkDescription").Name.ShouldEqual("SapMarkDescription");
            _dataFields.FirstOrDefault(x => x.Name == "SapMarkDescription").Type.ShouldEqual(typeof(string));

            _dataFields.FirstOrDefault(x => x.Name == "HasIssues").Name.ShouldEqual("HasIssues");
            _dataFields.FirstOrDefault(x => x.Name == "HasIssues").Type.ShouldEqual(typeof(bool));

            _dataFields.FirstOrDefault(x => x.Name == "HasErrors").Name.ShouldEqual("HasErrors");
            _dataFields.FirstOrDefault(x => x.Name == "HasErrors").Type.ShouldEqual(typeof(bool));

            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldEqual("CarFullname");
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string));
        }
    }
}