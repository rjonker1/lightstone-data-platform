using Lim.Domain.Client.Commands;

namespace Lim.Domain.Client.Handlers
{
    public interface IHandleSavingClient
    {
        bool IsSaved { get; }
        void Handle(AddClient command);
        void Handle(UpdateClient command);
    }
}