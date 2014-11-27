using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Ivid
{
    public class IvidDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;

        public IvidDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var spec = new CanHandlePackageSpecification(Services.Ivid, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleIvidSourceCall(), new CallIvidDataProvider(_request));
                consumer.ConsumeExternalSource(response, monitoring);

                if (response.IvidResponse == null)
                    CallFallbackSource(response, monitoring);
            }

            CallNextSource(response, monitoring);
        }


        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }
    }
}
