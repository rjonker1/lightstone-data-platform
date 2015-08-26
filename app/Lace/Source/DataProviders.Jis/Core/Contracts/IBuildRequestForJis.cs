using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Core.Contracts
{
    public interface IBuildRequestForJis
    {
        DataStoreRequest JisRequest { get; }
        IBuildRequestForJis Build();
    }
}
