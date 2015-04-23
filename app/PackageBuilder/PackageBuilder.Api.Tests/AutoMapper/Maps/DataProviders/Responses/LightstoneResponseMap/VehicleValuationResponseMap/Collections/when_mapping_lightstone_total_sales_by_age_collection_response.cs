﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Metric;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_total_sales_by_age_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithTotalSalesByAgeModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.TotalSalesByAge);
        }

        [Observation]
        public void should_map_total_sales_by_age_data_fields()
        {
            _dataField.Name.ShouldEqual("TotalSalesByAge");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByAgeModel>).ToString());

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            dataFields.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string).ToString());

            dataFields.FirstOrDefault(x => x.Name == "Values").Name.ShouldEqual("Values");
            dataFields.FirstOrDefault(x => x.Name == "Values").Type.ShouldEqual(typeof(IPair<string, double>[]).ToString());
        }
    }
}