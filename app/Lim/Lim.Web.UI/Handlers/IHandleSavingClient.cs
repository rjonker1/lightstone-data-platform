using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleSavingClient
    {
        bool IsSaved { get; }
        void Handle(AddClient command);
        void Handle(UpdateClient command);
    }
}