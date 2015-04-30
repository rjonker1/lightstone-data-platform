using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingAudatexExternalWebService : ICallTheDataProviderSource
    {
        private GetDataResult _audatexResponse;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public FakeCallingAudatexExternalWebService(ICollection<IPointToLaceRequest> request,  ISendCommandToBus command)
        {
            _request = request;
            _command = command;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _audatexResponse = new SourceResponseBuilder().ForAudatexWithHuyandaiHistory();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformAudatexResponse(_audatexResponse, response, _request.GetFromRequest<IPointToVehicleRequest>().Vehicle);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
