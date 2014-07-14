using Lace.Events;
using Lace.Response;

namespace Lace.Source
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

        public void CallNextSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            if (Next == null) return;

            Next.CallSource(response, laceEvent);
        }

        public void CallFallbackSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response, laceEvent);
        }
    }
}
