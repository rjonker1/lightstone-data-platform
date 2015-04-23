using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Entities.Requests;
using Lace.Domain.Core.Entities.Requests.Fields;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataProviders.Requests
{
    public class when_mapping_ivid_request : when_not_persisting_entities
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            base.Observe();

            _dataFields =
                Mapper.Map<IAmDataProviderRequest, IEnumerable<IDataField>>(
                    new IvidStandardRequest(new RequesterNameRequestField(), new RequesterPhoneRequestField(),
                        new RequesterEmailRequestField(), new RequestReferenceRequestField("sdfsdf"),
                        new ApplicantNameRequestField(), new ReasonForApplicationRequestField(), new LabelRequestField(),
                        new EngineNumberRequestField(), new RegisterNumberRequestField(),
                        new LicenseNumberRequestField(), new MakeRequestField()));
        }

        [Observation]
        public void should_map_all_ivid_data_fields()
        {
            _dataFields.Count().ShouldEqual(11);

            var test = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(_dataFields);
        }
    }
}