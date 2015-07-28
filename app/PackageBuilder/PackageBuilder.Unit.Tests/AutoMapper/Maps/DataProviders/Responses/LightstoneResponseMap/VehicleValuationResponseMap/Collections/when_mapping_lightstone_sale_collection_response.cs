﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
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
            _dataField.Name.ShouldEqual("LastFiveSales");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithSaleModel>).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(3);

            dataFields.FirstOrDefault(x => x.Name == "SalesDate").Name.ShouldEqual("SalesDate");
            dataFields.FirstOrDefault(x => x.Name == "SalesDate").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Name.ShouldEqual("LicensingDistrict");
            dataFields.FirstOrDefault(x => x.Name == "LicensingDistrict").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "SalesPrice").Name.ShouldEqual("SalesPrice");
            dataFields.FirstOrDefault(x => x.Name == "SalesPrice").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}