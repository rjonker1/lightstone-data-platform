using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleSavingConfiguration
    {
        bool IsSaved { get; }
        void Handle(InsertApiPushConfiguration command);
        void Handle(UpdateApiPushConfiguration command);
        void Handle(InsertApiPullConfiguration command);
    }
}
