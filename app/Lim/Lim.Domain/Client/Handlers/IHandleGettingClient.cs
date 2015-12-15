using Lim.Domain.Client.Commands;

namespace Lim.Domain.Client.Handlers
{
    public interface IHandleGettingIntegrationClient
    {
        void Handle(GetIntegrationClients command);
        void Handle(GetIntegrationClient command);
    }
}