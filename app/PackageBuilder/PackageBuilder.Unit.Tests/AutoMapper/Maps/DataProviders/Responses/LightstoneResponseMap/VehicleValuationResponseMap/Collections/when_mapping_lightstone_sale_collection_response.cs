using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_sale_collection_response : BaseTestHelper
    {
        private IDataField _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IEnumerable<IRespondWithSaleModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.LastFiveSales);
        }

        [Observation]
        public void should_map_sale_data_fields()
        {
            _dataField.Type.ShouldEqual(typeof(IRespondWithSaleModel[]).ToString());

            var dataFields = _dataField.DataFields;
            dataFields.Count().ShouldEqual(2);

            var saleModel = dataFields.FirstOrDefault();
            saleModel.Name.ShouldEqual("SaleModel");
            saleModel.Type.ShouldEqual(typeof(SaleModel).ToString());
            saleModel.DataFields.Count().ShouldEqual(3);

            saleModel.DataFields.FirstOrDefault(x => x.Name == "SalesDate").Name.ShouldEqual("SalesDate");
            saleModel.DataFields.FirstOrDefault(x => x.Name == "SalesDate").Type.ShouldEqual(typeof(string).ToString());

            saleModel.DataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Name.ShouldEqual("LicensingDistrict");
            saleModel.DataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Type.ShouldEqual(typeof(string).ToString());

            saleModel.DataFields.FirstOrDefault(x => x.Name == "SalesPrice").Name.ShouldEqual("SalesPrice");
            saleModel.DataFields.FirstOrDefault(x => x.Name == "SalesPrice").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}