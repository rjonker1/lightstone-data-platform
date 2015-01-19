using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IExecuteTheDataProviderSource
    {
        void CallSource(IProvideResponseFromLaceDataProviders response);
    }
}
