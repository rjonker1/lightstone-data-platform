using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.Lighstone;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeLightstoneSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public FakeLightstoneSourceExecution(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }


        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Lightstone, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleLighstoneSourceCall(),
                    new CallLightstoneDataProvider(_request, new FakeRepositoryFactory(),new FakeCarRepositioryFactory()));
                consumer.ConsumeExternalSource(response, _monitoring);

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
