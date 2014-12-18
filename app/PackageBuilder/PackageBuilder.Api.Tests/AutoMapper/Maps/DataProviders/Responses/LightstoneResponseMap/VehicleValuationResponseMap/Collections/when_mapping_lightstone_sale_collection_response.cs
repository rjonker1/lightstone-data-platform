using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_sale_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

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