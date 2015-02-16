using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities.Commands.Contracts;

namespace UserManagement.Domain.CommandHandlers.Contracts
{
    public class GetContractPackageHandler : AbstractMessageHandler<GetPackageOnContract>
    {
        public ContractPackageResponseDto Response { get; private set; }
        private readonly IRepository<Contract> _repository;

        public GetContractPackageHandler(IRepository<Contract> repository)
        {
            _repository = repository;
        }

        public override void Handle(GetPackageOnContract command)
        {
            var response = _repository.Get(command.ContractId);
            Response = response == null
                ? new ContractPackageResponseDto()
                : new ContractPackageResponseDto(response.Id,
                    response.Packages.FirstOrDefault(w => w.IsActivated.HasValue && w.IsActivated.Value));
        }
    }
}
