using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Domain.DataProviders.PCubed.Infrastructure.Management;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingPCubedDataProvider : ICallTheDataProviderSource
    {
        private string _response;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            _response = string.Empty; //TODO: Build fake response for PCbubed

            TransformResponse(response, monitoring);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformPCubedResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
