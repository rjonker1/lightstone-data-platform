using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public class ExecuteSourceBase
    {
        public IExecuteTheDataProviderSource Next { get; private set; }
        public IExecuteTheDataProviderSource FallBack { get; private set; }

        public ExecuteSourceBase(IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource)
        {
            Next = nextSource;
            FallBack = fallbackSource;
        }

        public void CallNextSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            if (Next == null) return;

            Next.CallSource(response, laceEvent);
        }

        public void CallFallbackSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response, laceEvent);
        }
    }
}
