using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeRgtVinSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly IHandleDataProviderSourceCall _handleServiceCall;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICallTheDataProviderSource _externalWebServiceCall;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public FakeRgtVinSourceExecution(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _handleServiceCall = new FakeHandleRgtVinServiceCall();
            _externalWebServiceCall = new FakeCallingRgtVinExternalWebService();
            _monitoring = monitoring;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleRgtServiceCall(),
                    new FakeCallingRgtVinExternalWebService());
                consumer.ConsumeExternalSource(response, _monitoring);

                if (!response.OfType<IProvideDataFromRgtVin>().Any() || response.OfType<IProvideDataFromRgtVin>().First() == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponseHandled = new RgtVinResponse();
            rgtVinResponseHandled.HasNotBeenHandled();
            response.Add(rgtVinResponseHandled);
        }
    }
}
