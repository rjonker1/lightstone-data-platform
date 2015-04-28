using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeRgtVinSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly IHandleDataProviderSourceCall _handleServiceCall;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;
        private readonly ISendCommandToBus _command;

        public FakeRgtVinSourceExecution(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _handleServiceCall = new FakeHandleRgtVinServiceCall();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleRgtServiceCall(),
                    new FakeCallingRgtVinExternalWebService());
                consumer.ConsumeExternalSource(response, _command);

                if (!response.OfType<IProvideDataFromRgtVin>().Any() || response.OfType<IProvideDataFromRgtVin>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponseHandled = new RgtVinResponse();
            rgtVinResponseHandled.HasNotBeenHandled();
            response.Add(rgtVinResponseHandled);
        }
    }
}
