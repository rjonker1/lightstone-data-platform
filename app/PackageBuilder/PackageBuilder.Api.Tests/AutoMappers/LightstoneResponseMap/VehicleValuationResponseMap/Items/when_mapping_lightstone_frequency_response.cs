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
    public class when_mapping_lightstone_frequency_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithFrequencyModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.Frequency.First());
        }

        [Observation]
        public void should_map_frequency_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            _dataField.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}