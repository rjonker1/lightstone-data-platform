﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.DataProviderResponses.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_repair_index_collection_response : when_not_persisting_entities
    {
        private IDataField _dataField;

        public override void Observe()
        {
            base.Observe();

            _dataField = Mapper.Map<IEnumerable<IRespondWithRepairIndexModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.RepairIndex);
        }

        [Observation]
        public void should_map_repair_index_data_fields()
        {
            _dataField.Name.ShouldEqual("RepairIndex");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithRepairIndexModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(3);

            dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            dataFields.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
            dataFields.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}