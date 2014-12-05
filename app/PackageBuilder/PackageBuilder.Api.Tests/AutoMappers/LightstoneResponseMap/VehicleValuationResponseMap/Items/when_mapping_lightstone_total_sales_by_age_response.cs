using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_total_sales_by_age_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithTotalSalesByAgeModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.TotalSalesByAge.First());
        }

        [Observation]
        public void should_map_total_sales_by_age_data_fields()
        {
            _dataField.Count().ShouldEqual(2);

            _dataField.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            _dataField.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "Values").Name.ShouldEqual("Values");
            _dataField.FirstOrDefault(x => x.Name == "Values").Type.ShouldEqual(typeof(IPair<string, double>[]));
        }
    }
}