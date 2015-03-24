using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
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

        public void CallNextSource(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            if (Next == null) return;

            Next.CallSource(response);
        }

        public void CallFallbackSource(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response);
        }
    }
}
