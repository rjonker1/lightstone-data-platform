using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

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

        public void CallNextSource(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            if (Next == null) return;

            Next.CallSource(response);
        }

        public void CallFallbackSource(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response);
        }
    }
}
