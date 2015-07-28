﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    /// <summary>
    /// IRespondWithTotalSalesByAgeModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_total_sales_by_age_response : when_not_persisting_entities
    //{
    //    private IEnumerable<IDataField> _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IRespondWithTotalSalesByAgeModel, IEnumerable<DataField>>(LightstoneResponseMother.Response.VehicleValuation.TotalSalesByAge.First());
    //    }

    //    [Observation]
    //    public void should_map_total_sales_by_age_data_fields()
    //    {
    //        _dataField.Count().ShouldEqual(2);

    //        _dataField.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
    //        _dataField.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string).ToString());

    //        _dataField.FirstOrDefault(x => x.Name == "Values").Name.ShouldEqual("Values");
    //        _dataField.FirstOrDefault(x => x.Name == "Values").Type.ShouldEqual(typeof(IPair<string, double>[]).ToString());
    //    }
    //}
}