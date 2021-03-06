﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneAutoResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_price_response : BaseTestHelper
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            _dataField = Mapper.Map<IRespondWithPriceModel, IEnumerable<DataField>>(LightstoneAutoResponseMother.Response.VehicleValuation.Prices.First());
        }

        [Observation]
        public void should_map_price_data_fields()
        {
            _dataField.Count().ShouldEqual(2);

            _dataField.FirstOrDefault(x => x.Name == "Name").Name.ShouldEqual("Name");
            _dataField.FirstOrDefault(x => x.Name == "Name").Type.ShouldEqual(typeof(string).ToString());

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
        }
    }
}