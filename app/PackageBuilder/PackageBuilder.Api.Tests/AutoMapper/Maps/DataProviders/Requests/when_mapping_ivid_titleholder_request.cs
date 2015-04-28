using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Fields;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;
using IAmDataProviderRequest = Lace.Domain.Core.Requests.Contracts.Requests.IAmDataProviderRequest;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Requests
{
    public class when_mapping_ivid_titleholder_request : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            //_dataFields =
            //    Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(
            //        new IvidTitleholderRequest(
            //            new RequesterNameRequestField(""),
            //            new RequesterPhoneRequestField(""),
            //            new RequesterEmailRequestField(""),
            //            new VinNumberRequestField("")));
        }

        [Observation]
        public void should_map_all_ivid_titleholder_data_fields()
        {
            _dataFields.Count().ShouldEqual(4);
            _dataFields.FirstOrDefault(x => x.Name == "Requester Name").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Requester Phone").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Requester Email").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Vin Number").ShouldNotBeNull();

            var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(_dataFields);

            var types = requestFields.Select(x => x.GetType());
            types.Count().ShouldEqual(4);
            types.ShouldContain(typeof(RequesterNameRequestField));
            types.ShouldContain(typeof(RequesterPhoneRequestField));
            types.ShouldContain(typeof(RequesterEmailRequestField));
            types.ShouldContain(typeof(VinNumberRequestField));
        }
    }
}