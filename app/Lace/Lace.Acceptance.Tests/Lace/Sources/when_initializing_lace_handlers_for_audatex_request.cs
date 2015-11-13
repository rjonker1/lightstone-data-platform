using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_audatex_request : Specification
    {

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_audatex_request()
        {
            _command = MonitoringBusBuilder.ForAudatexCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForAudatex();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
          //  _dataProvider = new AudatexDataProvider(_request, null, null,_command);
        }


        public override void Observe()
        {
          //  _dataProvider.CallSource(_response);
        }

       // [Observation]
        public void lace_functional_test_response_for_audatex_to_be_returned_should_be_one_test()
        {
            _response.ShouldNotBeNull();
        }


      //  [Observation]
        public void lace_functional_test_audatex_response_should_be_handled_test()
        {
            _response.OfType<IProvideDataFromAudatex>().First().Handled.ShouldBeTrue();
        }

       // [Observation]
        public void lace_functional_test_audatex_response_shuould_not_be_null_test()
        {
            _response.OfType<IProvideDataFromAudatex>().First().ShouldNotBeNull();
        }
    }
}
