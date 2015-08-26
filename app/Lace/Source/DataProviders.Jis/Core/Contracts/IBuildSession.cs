using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Core.Contracts
{
    public interface IBuildSession
    {
        SessionManagementResult SessionManagement { get; }
        IBuildSession Build();
    }
}
