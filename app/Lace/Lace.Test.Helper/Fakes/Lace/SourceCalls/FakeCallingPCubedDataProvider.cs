using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Domain.DataProviders.PCubed.Infrastructure.Management;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingPCubedDataProvider : ICallTheDataProviderSource
    {
        private string _response;

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringCommandsToBus monitoring)
        {
            _response = string.Empty; //TODO: Build fake response for PCbubed

            TransformResponse(response, monitoring);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformPCubedResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.FicaVerficationResponse = transformer.Result;
            response.FicaVerficationResponseHandled = new PCubedFicaVerficationResponseHandled();
            response.FicaVerficationResponseHandled.HasBeenHandled();
        }
    }
}
