using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lsp;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Scans;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_Lsp : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ISendCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_Lsp()
        {
            _monitoring = BusBuilder.ForLspCommands(Guid.NewGuid());
            _request = new LspRequestBuilder().ForReturnProperties();
            _response = new LaceResponse();
            _dataProvider = new LspDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            //_dataProvider.CallSource(_response);
        }

      //  [Observation]
        public void lace_Lsp_response_should_be_handled_test()
        {
            _response.LspResponseHandled.Handled.ShouldBeTrue();
        }

        //[Observation]
        public void lace_Lsp_response_shuould_not_be_null_test()
        {
            _response.LspResponse.ShouldNotBeNull();
        }
        
    }
}
