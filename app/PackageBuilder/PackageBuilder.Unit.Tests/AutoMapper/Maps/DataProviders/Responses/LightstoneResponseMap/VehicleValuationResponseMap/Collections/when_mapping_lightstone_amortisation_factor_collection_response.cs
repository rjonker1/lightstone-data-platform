﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    /// <summary>
    /// IRespondWithAmortisationFactorModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_amortisation_factor_collection_response : when_not_persisting_entities
    //{
    //    private IDataField _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IEnumerable<IRespondWithAmortisationFactorModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.AmortisationFactors);
    //    }

    //    [Observation]
    //    public void should_map_amortisation_factor_data_fields()
    //    {
    //        _dataField.Name.ShouldEqual("AmortisationFactors");
    //        _dataField.Type.ShouldEqual(typeof(List<IRespondWithAmortisationFactorModel>).ToString());

    //        var dataFields = _dataField.DataFields;

    //        dataFields.Count().ShouldEqual(2);

    //        dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
    //        dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int).ToString());

    //        dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
    //        dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
    //    }
    //}
}