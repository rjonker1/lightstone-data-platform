using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

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

        public void CallNextSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            if (Next == null) return;

            Next.CallSource(response, monitoring);
        }

        public void CallFallbackSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response, monitoring);
        }
    }
}
