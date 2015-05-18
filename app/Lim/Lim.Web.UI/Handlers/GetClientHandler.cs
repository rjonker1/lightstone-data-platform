using Lim.Web.UI.Commands;
using Lim.Web.UI.Models;
using Lim.Web.UI.Repository;

namespace Lim.Web.UI.Handlers
{
    public class GetClientHandler : IHandleGettingClient
    {
        private readonly IUserManagementRepository _repository;

        public GetClientHandler(IUserManagementRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetClients command)
        {
            command.Set(_repository.Items<Client>(Client.Select, new {}));
        }

        public void Handle(GetClientPackages command)
        {
            command.Set(_repository.Items<Package>(Package.Select, new {}));
        }

        public void Handle(GetClientContracts command)
        {
            command.Set(_repository.Items<Contract>(Contract.Select, new {}));
        }
    }
}