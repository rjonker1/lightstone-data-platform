using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_sale_response : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IRespondWithSaleModel, IEnumerable<DataField>>(LightstoneResponseMother.Response.VehicleValuation.LastFiveSales.First());
        }

        [Observation]
        public void should_map_sale_data_fields()
        {
            _dataField.Count().ShouldEqual(3);

            _dataField.FirstOrDefault(x => x.Name == "SalesDate").Name.ShouldEqual("SalesDate");
            _dataField.FirstOrDefault(x => x.Name == "SalesDate").Type.ShouldEqual(typeof(string).ToString());

            _dataField.FirstOrDefault(x => x.Name == "LicensingDistrict").Name.ShouldEqual("LicensingDistrict");
            _dataField.FirstOrDefault(x => x.Name == "LicensingDistrict").Type.ShouldEqual(typeof(string).ToString());

            _dataField.FirstOrDefault(x => x.Name == "SalesPrice").Name.ShouldEqual("SalesPrice");
            _dataField.FirstOrDefault(x => x.Name == "SalesPrice").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}