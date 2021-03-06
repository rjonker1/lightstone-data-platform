﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses
{
    public class when_mapping_rgt_vin_response : BaseTestHelper
    {
        private IEnumerable<IDataField> _dataFields;

        public override void Observe()
        {
            _dataFields = Mapper.Map<IProvideDataFromRgtVin, IEnumerable<DataField>>(RgtVinResponseMother.Response);
        }

        [Observation]
        public void should_map_all_rgt_vin_data_fields()
        {
            _dataFields.Count().ShouldEqual(11);

            _dataFields.FirstOrDefault(x => x.Name == "Vin").Name.ShouldEqual("Vin");
            _dataFields.FirstOrDefault(x => x.Name == "Vin").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "VehicleMake").Name.ShouldEqual("VehicleMake");
            _dataFields.FirstOrDefault(x => x.Name == "VehicleMake").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "VehicleType").Name.ShouldEqual("VehicleType");
            _dataFields.FirstOrDefault(x => x.Name == "VehicleType").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "VehicleModel").Name.ShouldEqual("VehicleModel");
            _dataFields.FirstOrDefault(x => x.Name == "VehicleModel").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "Month").Name.ShouldEqual("Month");
            _dataFields.FirstOrDefault(x => x.Name == "Month").Type.ShouldEqual(typeof(int?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "Quarter").Name.ShouldEqual("Quarter");
            _dataFields.FirstOrDefault(x => x.Name == "Quarter").Type.ShouldEqual(typeof(int?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "RgtCode").Name.ShouldEqual("RgtCode");
            _dataFields.FirstOrDefault(x => x.Name == "RgtCode").Type.ShouldEqual(typeof(int?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "Price").Name.ShouldEqual("Price");
            _dataFields.FirstOrDefault(x => x.Name == "Price").Type.ShouldEqual(typeof(decimal?).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "Colour").Name.ShouldEqual("Colour");
            _dataFields.FirstOrDefault(x => x.Name == "Colour").Type.ShouldEqual(typeof(string).ToString());

            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Name.ShouldEqual("CarFullname");
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string).ToString());
        }
    }
}