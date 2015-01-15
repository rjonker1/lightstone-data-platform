using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_audatex_request : Specification
    {

        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_audatex_request()
        {
            _monitoring = BusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForAudatex();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider = new AudatexDataProvider(_request, null, null,_monitoring);
        }


        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_functional_test_response_for_audatex_to_be_returned_should_be_one_test()
        {
            _response.ShouldNotBeNull();
        }


        [Observation]
        public void lace_functional_test_audatex_response_should_be_handled_test()
        {
            _response.AudatexResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_audatex_response_shuould_not_be_null_test()
        {
            _response.AudatexResponse.ShouldNotBeNull();
        }
    }
}
