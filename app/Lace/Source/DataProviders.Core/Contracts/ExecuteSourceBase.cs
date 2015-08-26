using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Workflow.Lace.Messages.Core;


namespace Lace.Domain.DataProviders.Core.Contracts
{
    public class ExecuteSourceBase
    {
        public IExecuteTheDataProviderSource Next { get; private set; }
        public IExecuteTheDataProviderSource FallBack { get; private set; }
        public IExecuteTheDataProviderSource Lookup { get; private set; }

        public ExecuteSourceBase(IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource)
        {
            Next = nextSource;
            FallBack = fallbackSource;
        }

        public void CallNextSource(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            if (Next == null) return;

            Next.CallSource(response);
        }

        public void CallFallbackSource(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            if (FallBack == null) return;

            FallBack.CallSource(response);
        }

        public void CallLookupSource(ICollection<IPointToLaceProvider> response, ISendCommandToBus command)
        {
            if (Lookup == null) return;

            Lookup.CallSource(response);
        }
    }
}
