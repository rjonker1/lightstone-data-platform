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
    public class when_mapping_lightstone_sale_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithSaleModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.LastFiveSales);
        }

        [Observation]
        public void should_map_sale_data_fields()
        {
            _dataField.Name.ShouldEqual("LastFiveSales");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithSaleModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(3);

            dataFields.FirstOrDefault(x => x.Name == "SalesDate").Name.ShouldEqual("SalesDate");
            dataFields.FirstOrDefault(x => x.Name == "SalesDate").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Name.ShouldEqual("LicensingDistrict");
            dataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "SalesPrice").Name.ShouldEqual("SalesPrice");
            dataFields.FirstOrDefault(x => x.Name == "SalesPrice").Type.ShouldEqual(typeof(string));
        }
    }
}