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
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using DataProviderName = PackageBuilder.Domain.Entities.Enums.DataProviders.DataProviderName;

namespace Lace.Domain.DataProviders.Lightstone.Property
{
    public class LightstonePropertyDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public LightstonePropertyDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
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

                _command.Monitoring.Begin(new {_request}, stopWatch);

                var consumer = new ConsumeSource(new HandleLightstonePropertyCall(),
                    new CallLightstonePropertyDataProvider(_request));
                consumer.ConsumeExternalSource(response, _command);

                _command.Monitoring.End(response, stopWatch);

                if (!response.OfType<IProvideDataFromLightstoneProperty>().Any() || response.OfType<IProvideDataFromLightstoneProperty>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var lightstonePropertyResponse = new LightstonePropertyResponse();
            lightstonePropertyResponse.HasNotBeenHandled();
            response.Add(lightstonePropertyResponse);
        }
    }
}
