﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    /// <summary>
    /// IRespondWithAuctionFactorModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_auction_factor_response : when_not_persisting_entities
    //{
    //    private IEnumerable<IDataField> _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IRespondWithAuctionFactorModel, IEnumerable<DataField>>(LightstoneResponseMother.Response.VehicleValuation.AuctionFactors.First());
    //    }

    //    [Observation]
    //    public void should_map_auction_factor_data_fields()
    //    {
    //        _dataField.Count().ShouldEqual(2);

    //        _dataField.FirstOrDefault(x => x.Name == "Make").Name.ShouldEqual("Make");
    //        _dataField.FirstOrDefault(x => x.Name == "Make").Type.ShouldEqual(typeof(string).ToString());

    //        _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
    //        _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
    //    }
    //}
}