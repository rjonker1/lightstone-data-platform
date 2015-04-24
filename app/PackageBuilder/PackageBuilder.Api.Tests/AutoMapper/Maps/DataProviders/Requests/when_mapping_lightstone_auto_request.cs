using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Entities.RequestFields;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Requests
{
    public class when_mapping_lightstone_auto_request : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            _dataFields = Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(new LightstoneAutoRequest(new CarIdRequestField(""), new YearRequestField(""), new MakeRequestField(""), new VinNumberRequestField("")));
        }

        [Observation]
        public void should_map_all_lightstone_auto_data_fields()
        {
            _dataFields.Count().ShouldEqual(4);
            _dataFields.FirstOrDefault(x => x.Name == "Car Id").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Year").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Make").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Vin Number").ShouldNotBeNull();

            var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(_dataFields);
            var types = requestFields.Select(x => x.GetType());
            types.Count().ShouldEqual(4);
            types.ShouldContain(typeof(CarIdRequestField));
            types.ShouldContain(typeof(YearRequestField));
            types.ShouldContain(typeof(MakeRequestField));
            types.ShouldContain(typeof(VinNumberRequestField));
        }
    }
}