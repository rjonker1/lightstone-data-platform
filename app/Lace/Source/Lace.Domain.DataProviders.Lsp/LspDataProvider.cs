using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lsp.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Lsp
{
    public class LspDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ILaceRequest _request;
        private readonly ISendCommandsToBus _monitoring;

        public LspDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandsToBus monitoring)
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

                // TODO: implement once core package is published
                //_monitoring.Begin(new {_request.Property}, stopWatch);

                var consumer = new ConsumeSource(new HandleLspSourceCall(), new CallLspDataProvider(_request));
                consumer.ConsumeExternalSource(response, _monitoring);

                _monitoring.End(response, stopWatch);

                if (response.LightstoneResponse == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.LightstoneResponse = null;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasNotBeenHandled();
        }
    }
}
