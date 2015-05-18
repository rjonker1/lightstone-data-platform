using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleGettingConfiguration
    {
        void Handle(GetFrequencyTypes command);
        void Handle(GetIntegrationTypes command);
        void Handle(GetAuthenticationTypes command);
        void Handle(GetActionType command);
        void Handle(GetApiPushConfiguration command);
        void Handle(GetApiPullConfiguration command);
    }
}