using System.Net.NetworkInformation;
using Lim.Domain.Models;
using Lim.Domain.Repository;
using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public class GetDataPlatformClientHandler : IHandleGettingDataPlatformClient
    {
        private readonly IUserManagementRepository _repository;

        public GetDataPlatformClientHandler(IUserManagementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetDataPlatformClients command)
        {
            command.Set(_repository.Items<DataPlatformClient>(DataPlatformClient.Select, new {}));
        }

        public void Handle(GetDataPlatformClientPackages command)
        {
            command.Set(_repository.Items<DataPlatformPackage>(DataPlatformPackage.Select, new {}));
        }

        public void Handle(GetDataPlatformClientContracts command)
        {
            command.Set(_repository.Items<DataPlatformContract>(DataPlatformContract.Select, new {}));
        }
    }

    public class GetIntegrationClientHandler : IHandleGettingIntegrationClient
    {
        private readonly ILimRepository _repository;

        public GetIntegrationClientHandler(ILimRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetIntegrationClients command)
        {
            command.Set(_repository.Items<Client>(Client.Select, new {}));
        }
    }
}