using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IRequestDataFromDataProviderSource
    {
        void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalSource, ISendCommandsToBus monitoring);
    }
}
