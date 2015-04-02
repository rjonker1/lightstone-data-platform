using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Builders.Responses;
using Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingSignioDataProvider : ICallTheDataProviderSource
    {
        private string _resonse;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {

            _resonse = new SourceResponseBuilder().ForSignioDriversLicenseDecryptedResponse();
            TransformResponse(response, command);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer =
                new TransformSignioResponse(
                    _resonse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
