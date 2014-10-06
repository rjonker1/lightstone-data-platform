using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public class ExecuteSourceBase
    {
        public IExecuteTheSource Next { get; private set; }
        public IExecuteTheSource FallBack { get; private set; }

        public ExecuteSourceBase(IExecuteTheSource nextSource, IExecuteTheSource fallbackSource)
        {
            Next = nextSource;
            FallBack = fallbackSource;
        }

        public void CallNextSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            if (Next == null) return;

            Next.CallSource(response, laceEvent);
        }

        public void CallFallbackSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response, laceEvent);
        }
    }
}
