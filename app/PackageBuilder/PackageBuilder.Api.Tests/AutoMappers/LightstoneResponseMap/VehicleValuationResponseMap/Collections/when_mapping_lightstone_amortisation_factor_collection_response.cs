using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_amortisation_factor_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithAmortisationFactorModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.AmortisationFactors);
        }

        [Observation]
        public void should_map_amortisation_factor_data_fields()
        {
            _dataField.Name.ShouldEqual("AmortisationFactors");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithAmortisationFactorModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }

    public class when_mapping_lightstone_price_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithPriceModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.Prices);
        }

        [Observation]
        public void should_map_price_data_fields()
        {
            _dataField.Name.ShouldEqual("Prices");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithPriceModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Name").Name.ShouldEqual("Name");
            dataFields.FirstOrDefault(x => x.Name == "Name").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal));
        }
    }
}