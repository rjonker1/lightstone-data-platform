using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_area_factor_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IRespondWithAreaFactorModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.AreaFactors.First());
        }

        [Observation]
        public void should_map_area_factor_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "Municipality").Name.ShouldEqual("Municipality");
            _dataField.FirstOrDefault(x => x.Name == "Municipality").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "Index").Name.ShouldEqual("Index");
            _dataField.FirstOrDefault(x => x.Name == "Index").Type.ShouldEqual(typeof(int));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}