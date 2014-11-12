using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_estimated_value_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithEstimatedValueModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.EstimatedValue.First());
        }

        [Observation]
        public void should_map_estimated_value_data_fields()
        {
            _dataField.Count().ShouldEqual(5);

            _dataField.FirstOrDefault(x => x.Name == "EstimatedValue").Name.ShouldEqual("EstimatedValue");
            _dataField.FirstOrDefault(x => x.Name == "EstimatedValue").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "EstimatedLow").Name.ShouldEqual("EstimatedLow");
            _dataField.FirstOrDefault(x => x.Name == "EstimatedLow").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "EstimatedHigh").Name.ShouldEqual("EstimatedHigh");
            _dataField.FirstOrDefault(x => x.Name == "EstimatedHigh").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "ConfidenceValue").Name.ShouldEqual("ConfidenceValue");
            _dataField.FirstOrDefault(x => x.Name == "ConfidenceValue").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "ConfidenceLevel").Name.ShouldEqual("ConfidenceLevel");
            _dataField.FirstOrDefault(x => x.Name == "ConfidenceLevel").Type.ShouldEqual(typeof(string));
        }
    }
}