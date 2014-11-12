using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_total_sales_by_age_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithTotalSalesByAgeModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.TotalSalesByAge);
        }

        [Observation]
        public void should_map_total_sales_by_age_data_fields()
        {
            _dataField.Name.ShouldEqual("TotalSalesByAge");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByAgeModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            dataFields.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Values").Name.ShouldEqual("Values");
            dataFields.FirstOrDefault(x => x.Name == "Values").Type.ShouldEqual(typeof(IPair<string, double>[]));
        }
    }
}