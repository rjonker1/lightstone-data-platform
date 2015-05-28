using Lim.Domain.Dto;
using Lim.Domain.Repository;
using Lim.Web.UI.Commands;

namespace Lim.Web.UI.Handlers
{
    public class GetDataPlatformClientHandler : IHandleGettingDataPlatformClient
    {
        private readonly IReadUserManagementRepository _repository;

        public GetDataPlatformClientHandler(IReadUserManagementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetDataPlatformClients command)
        {
            command.Set(_repository.Items<DataPlatformClientDto>(DataPlatformClientDto.Select, new { }));
        }

        public void Handle(GetDataPlatformClientPackages command)
        {
            command.Set(_repository.Items<DataPlatformPackageDto>(DataPlatformPackageDto.Select, new { }));
        }

        public void Handle(GetDataPlatformClientContracts command)
        {
            command.Set(_repository.Items<DataPlatformContractDto>(DataPlatformContractDto.Select, new { }));
        }
    }

    public class GetIntegrationClientHandler : IHandleGettingIntegrationClient
    {
        private readonly IReadLimRepository _repository;

        public GetIntegrationClientHandler(IReadLimRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetIntegrationClients command)
        {
            command.Set(_repository.Items<ClientDto>(ClientDto.SelectAll, new {}));
        }

        public void Handle(GetIntegrationClient command)
        {
            command.Set(_repository.Item<ClientDto>(ClientDto.Select, new {@Id = command.Id}));
        }
    }
}