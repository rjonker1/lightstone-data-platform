using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Ivid
{
    public class IvidDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public IvidDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Ivid, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
                _monitoring.Begin(new {_request.User, _request.Vehicle, _request.Context}, stopWatch);

                var consumer = new ConsumeSource(new HandleIvidSourceCall(), new CallIvidDataProvider(_request));
                consumer.ConsumeExternalSource(response, _monitoring);

                _monitoring.End(response, stopWatch);

                if (response.IvidResponse == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }


        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasNotBeenHandled();
        }
    }
}
