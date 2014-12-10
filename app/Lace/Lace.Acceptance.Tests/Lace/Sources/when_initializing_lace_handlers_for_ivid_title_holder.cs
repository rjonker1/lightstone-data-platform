using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_title_holder : Specification
    {

        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendMonitoringMessages _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_ivid_title_holder()
        {

            _monitoring = BusBuilder.ForMonitoringMessages(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider = new IvidTitleHolderDataProvider(_request, null, null);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response, _monitoring);
        }

        [Observation]
        public void lace_ivid_title_holder_response_should_be_handled_test()
        {
            _response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_ivid_title_holder_response_shuould_not_be_null_test()
        {
            _response.IvidTitleHolderResponse.ShouldNotBeNull();
        }
    }
}
