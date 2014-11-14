using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_area_factor_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithAreaFactorModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.AreaFactors);
        }

        [Observation]
        public void should_map_area_factor_data_fields()
        {
            _dataField.Name.ShouldEqual("AreaFactors");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithAreaFactorModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(3);

            dataFields.FirstOrDefault(x => x.Name == "Municipality").Name.ShouldEqual("Municipality");
            dataFields.FirstOrDefault(x => x.Name == "Municipality").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Index").Name.ShouldEqual("Index");
            dataFields.FirstOrDefault(x => x.Name == "Index").Type.ShouldEqual(typeof(int));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}