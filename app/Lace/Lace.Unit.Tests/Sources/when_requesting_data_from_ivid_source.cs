using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_ivid_source : Specification
    {
        private readonly IRequestDataFromDataProviderSource _requestDataFromService;
        private readonly ICollection<IPointToLaceRequest> _ividRequest;
        private ICollection<IPointToLaceProvider> _laceResponse;
        private readonly ISendCommandToBus _command;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;

        public when_requesting_data_from_ivid_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);
           
            _requestDataFromService = new RequestDataFromIvidSource();
            _ividRequest = new LicensePlateRequestBuilder().ForIvid();
            _laceResponse = new Collection<IPointToLaceProvider>();
            _externalWebServiceCall = new FakeCallingIvidExternalWebService();
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _command);
        }

        [Observation]
        public void lace_ivid_request_data_from_service_response_must_not_be_null()
        {
            _laceResponse.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_ivid_request_data_from_service_must_be_handled()
        {
            _laceResponse.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
        }
    }
}
