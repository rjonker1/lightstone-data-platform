using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps
{
    public class when_mapping_a_complex_object_to_a_data_field : BaseTestHelper
    {
        private IEnumerable<IDataField> _dataFields;

        public override void Observe()
        {
            var ivid = new IvidResponse();
            ivid.BuildSpecificInformation();

            _dataFields = Mapper.Map(ivid, ivid.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>;
        }

        [Observation]
        public void should_map_all_data_fields()
        {
            _dataFields.Count().ShouldEqual(32);
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string).ToString());
            _dataFields.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(7);
        }
    }
}