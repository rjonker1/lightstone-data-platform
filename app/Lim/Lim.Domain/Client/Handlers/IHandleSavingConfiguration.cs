using Lim.Domain.Pull.Commands;
using Lim.Domain.Push.Commands;

namespace Lim.Domain.Client.Handlers
{
    public interface IHandleSavingConfiguration
    {
        bool IsSaved { get; }
        void Handle(AddApiPushConfiguration command);
        void Handle(UpdateApiPushConfiguration command);
        void Handle(AddApiPullConfiguration command);
    }
}
