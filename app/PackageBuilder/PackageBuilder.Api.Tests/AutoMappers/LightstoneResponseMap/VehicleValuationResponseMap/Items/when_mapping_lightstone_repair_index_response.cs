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
    public class when_mapping_lightstone_repair_index_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithRepairIndexModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.RepairIndex.First());
        }

        [Observation]
        public void should_map_repair_index_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int)); 
            
            _dataField.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            _dataField.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}