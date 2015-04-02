using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingAudatexExternalWebService : ICallTheDataProviderSource
    {
        private GetDataResult _audatexResponse;
        private readonly ICollection<IPointToLaceRequest> _request;

        public FakeCallingAudatexExternalWebService(ICollection<IPointToLaceRequest> request)
        {
            _request = request;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            _audatexResponse = new SourceResponseBuilder().ForAudatexWithHuyandaiHistory();
            TransformResponse(response, monitoring);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
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
