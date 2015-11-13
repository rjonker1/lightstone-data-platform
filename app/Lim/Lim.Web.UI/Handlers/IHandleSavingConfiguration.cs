using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleSavingConfiguration
    {
        bool IsSaved { get; }
        void Handle(AddApiPushConfiguration command);
        void Handle(UpdateApiPushConfiguration command);
        void Handle(AddApiPullConfiguration command);
    }
}
