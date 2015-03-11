using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lightstone.Property
{
    public class LightstoneProperyDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public LightstoneProperyDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Lsp, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch =
                    new StopWatchFactory().StopWatchForDataProvider(
                        DataProviderCommandSource.Lsp);
                
                //_monitoring.Begin(new {_request.Property}, stopWatch);

                var consumer = new ConsumeSource(new HandleLightstonePropertyCall(), new CallLightstonePropertyDataProvider(_request));
                consumer.ConsumeExternalSource(response, _monitoring);

               // _monitoring.End(response, stopWatch);

                if (response.LightstonePropertyResponse == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstonePropertyResponse = null;
            response.LightstonePropertyResponseHandled = new LightstonePropertyResponseHandled();
            response.LightstonePropertyResponseHandled.HasNotBeenHandled();
        }
    }
}
