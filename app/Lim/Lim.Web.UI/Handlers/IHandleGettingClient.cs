using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public interface IHandleGettingDataPlatformClient
    {
        void Handle(GetDataPlatformClients command);
        void Handle(GetDataPlatformClientPackages command);
        void Handle(GetDataPlatformClientContracts command);
    }

    public interface IHandleGettingIntegrationClient
    {
        void Handle(GetIntegrationClients command);
        void Handle(GetIntegrationClient command);
    }
}
