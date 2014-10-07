using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Core.Contracts
{
    public interface IUpdateSighting
    {
        SightingUpdateResult SightingUpdateResult { get; }
        IUpdateSighting BuildRequest();
        IUpdateSighting Update(JisWsInterfaceSoapClient jisClient, SessionManagementResult session);
    }
}
