using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Requests;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;
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
                    new IvidStandardRequest(
                        new RequesterNameRequestField(""),
                        new RequesterPhoneRequestField(""),
                        new RequesterEmailRequestField(""),
                        new RequestReferenceRequestField(""),
                        new ApplicantNameRequestField(""),
                        new ReasonForApplicationRequestField(""),
                        new LabelRequestField(""),
                        new EngineNumberRequestField(""),
                        new ChassisNumberRequestField(""),
                        new VinNumberRequestField(""),
                        new LicenceNumberRequestField(""),
                        new RegisterNumberRequestField(""),
                        new MakeRequestField("")));
        }

        [Observation]
        public void should_map_all_ivid_data_fields()
        {
            _dataFields.Count().ShouldEqual(13);
            _dataFields.FirstOrDefault(x => x.Name == "Requester Name").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Requester Phone").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Requester Email").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Request Reference").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Applicant Name").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Reason For Application").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Label").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Vin Number").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Chassis Number").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Register Number").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Licence Number").ShouldNotBeNull();
            _dataFields.FirstOrDefault(x => x.Name == "Make").ShouldNotBeNull();

            var requestFields = Mapper.Map<IEnumerable<IDataField>, IEnumerable<IAmRequestField>>(_dataFields);

            var types = requestFields.Select(x => x.GetType());
            types.Count().ShouldEqual(13);
            types.ShouldContain(typeof(RequesterNameRequestField));
            types.ShouldContain(typeof(RequesterPhoneRequestField));
            types.ShouldContain(typeof(RequesterEmailRequestField));
            types.ShouldContain(typeof(RequestReferenceRequestField));
            types.ShouldContain(typeof(ApplicantNameRequestField));
            types.ShouldContain(typeof(ReasonForApplicationRequestField));
            types.ShouldContain(typeof(LabelRequestField));
            types.ShouldContain(typeof(VinNumberRequestField));
            types.ShouldContain(typeof(ChassisNumberRequestField));
            types.ShouldContain(typeof(EngineNumberRequestField));
            types.ShouldContain(typeof(RegisterNumberRequestField));
            types.ShouldContain(typeof(LicenceNumberRequestField));
            types.ShouldContain(typeof(MakeRequestField));
        }
    }
}