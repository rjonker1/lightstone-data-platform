using Lace.Source.Jis.JisServiceReference;

namespace Lace.Source.Jis.Builder
{
    public interface IBuildSession
    {
        SessionManagementResult SessionManagement { get; }
        IBuildSession Build();
    }
}
