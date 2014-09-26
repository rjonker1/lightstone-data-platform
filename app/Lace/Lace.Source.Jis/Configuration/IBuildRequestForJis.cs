using Lace.Source.Jis.JisServiceReference;

namespace Lace.Source.Jis.Configuration
{
    public interface IBuildRequestForJis
    {
        DataStoreRequest JisRequest { get; }
        IBuildRequestForJis Build();
    }
}
