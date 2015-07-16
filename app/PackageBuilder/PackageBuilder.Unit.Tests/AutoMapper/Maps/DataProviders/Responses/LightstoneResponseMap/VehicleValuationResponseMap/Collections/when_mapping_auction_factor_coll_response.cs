using System.Collections.Generic;
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
    /// <summary>
    /// IRespondWithAuctionFactorModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_auction_factor_collection_response : when_not_persisting_entities
    //{
    //    private IDataField _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IEnumerable<IRespondWithAuctionFactorModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.AuctionFactors);
    //    }

    //    [Observation]
    //    public void should_map_auction_factor_data_fields()
    //    {
    //        _dataField.Name.ShouldEqual("AuctionFactors");
    //        _dataField.Type.ShouldEqual(typeof(List<IRespondWithAuctionFactorModel>).ToString());

    //        var dataFields = _dataField.DataFields;

    //        dataFields.Count().ShouldEqual(2);

    //        dataFields.FirstOrDefault(x => x.Name == "Make").Name.ShouldEqual("Make");
    //        dataFields.FirstOrDefault(x => x.Name == "Make").Type.ShouldEqual(typeof(string).ToString());

    //        dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
    //        dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal).ToString());
    //    }
    //}
}