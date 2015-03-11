using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidExternalWebService : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            _ividResponse = new SourceResponseBuilder().ForIvid();
            TransformResponse(response, monitoring);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformIvidResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
