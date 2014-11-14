using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_sale_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithSaleModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.LastFiveSales.First());
        }

        [Observation]
        public void should_map_sale_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "SalesDate").Name.ShouldEqual("SalesDate");
            _dataField.FirstOrDefault(x => x.Name == "SalesDate").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "LicensingDistrict").Name.ShouldEqual("LicensingDistrict");
            _dataField.FirstOrDefault(x => x.Name == "LicensingDistrict").Type.ShouldEqual(typeof(string));

            _dataField.FirstOrDefault(x => x.Name == "SalesPrice").Name.ShouldEqual("SalesPrice");
            _dataField.FirstOrDefault(x => x.Name == "SalesPrice").Type.ShouldEqual(typeof(string));
        }
    }
}