using Lim.Domain.Client.Commands;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Pull.Commands;
using Lim.Domain.Push.Commands;
using Lim.Domain.Push.Ftp.Commands;

namespace Lim.Domain.Client.Handlers
{
    public interface IHandleGettingConfiguration
    {
        void Handle(GetFrequencyTypes command);
        void Handle(GetIntegrationTypes command);
        void Handle(GetAuthenticationTypes command);
        void Handle(GetActionType command);
        void Handle(GetApiPushConfiguration command);
        void Handle(GetApiPullConfiguration command);
        void Handle(GetAllConfigurations command);
        void Handle(GetWeekdays command);
        void Handle(GetFtpPushConfiguration command);
    }
}