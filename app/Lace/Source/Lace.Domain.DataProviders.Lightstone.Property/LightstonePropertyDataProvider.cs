using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lightstone.Property
{
    public class LightstonePropertyDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public LightstonePropertyDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LightstoneProperty, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch =
                    new StopWatchFactory().StopWatchForDataProvider(
                        DataProviderCommandSource.LightstoneProperty);

                _monitoring.Begin(new {_request.Property}, stopWatch);

                var consumer = new ConsumeSource(new HandleLightstonePropertyCall(),
                    new CallLightstonePropertyDataProvider(_request));
                consumer.ConsumeExternalSource(response, _monitoring);

                _monitoring.End(response, stopWatch);

                if (!response.OfType<IProvideDataFromLightstoneProperty>().Any() || response.OfType<IProvideDataFromLightstoneProperty>().First() == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var lightstonePropertyResponse = new LightstonePropertyResponse();
            lightstonePropertyResponse.HasNotBeenHandled();
            response.Add(lightstonePropertyResponse);
        }
    }
}
