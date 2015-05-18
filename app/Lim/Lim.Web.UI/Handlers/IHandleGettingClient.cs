using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleGettingClient
    {
        void Handle(GetClients command);
        void Handle(GetClientPackages command);
        void Handle(GetClientContracts command);
    }
}
