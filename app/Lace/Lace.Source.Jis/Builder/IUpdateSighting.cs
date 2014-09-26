using Lace.Source.Jis.JisServiceReference;

namespace Lace.Source.Jis.Builder
{
    public interface IUpdateSighting
    {
        SightingUpdateResult SightingUpdateResult { get; }
        IUpdateSighting BuildRequest();
        IUpdateSighting Update(JisWsInterfaceSoapClient jisClient, SessionManagementResult session);
    }
}
