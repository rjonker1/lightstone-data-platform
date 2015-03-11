using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.Infrastructure;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakePCubedDataProvider: ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public FakePCubedDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.PCubedFica, _request);
            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandlePCubedSourceCall(), new FakeCallingPCubedDataProvider());
                consumer.ConsumeExternalSource(response, _monitoring);
                
                if (response.FicaVerficationResponse == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.FicaVerficationResponse = null;
            response.FicaVerficationResponseHandled = new PCubedFicaVerficationResponseHandled();
            response.FicaVerficationResponseHandled.HasNotBeenHandled();
        }
    }
}
