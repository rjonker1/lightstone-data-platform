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
    public class when_mapping_lightstone_accident_distribution_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithAccidentDistributionModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.AccidentDistribution);
        }

        [Observation]
        public void should_map_accident_distribution_data_fields()
        {
            _dataField.Name.ShouldEqual("AccidentDistribution");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithAccidentDistributionModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            dataFields.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}