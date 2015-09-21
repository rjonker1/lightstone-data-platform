using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;

namespace DataProviders.Lightstone.MMCode
{
    public sealed class LightstoneAutoMMCodeDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        public LightstoneAutoMMCodeDataProvider(IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource) : base(nextSource, fallbackSource)
        {
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            throw new System.NotImplementedException();
        }
    }
}