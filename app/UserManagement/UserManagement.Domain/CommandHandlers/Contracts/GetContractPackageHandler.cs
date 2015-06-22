using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities.Commands.Contracts;
using UserManagement.Domain.Enums;

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
            //TDOD: Impleent once contract information is in the database
            //var response = _repository.Get(command.ContractId);
            var response = FakeContract(command.ContractId);

            Response = response == null
                ? new ContractPackageResponseDto()
                : new ContractPackageResponseDto(response.Id, response.Packages.FirstOrDefault());
        }

        private static Contract FakeContract(Guid contractId)
        {
            return new Contract(DateTime.Now, "VVI Product", null, null, null, null, null, null, EscalationType.AnnualPercentageAllProducts, null, contractId)
            {
                Id = contractId,
                Packages = new HashSet<Package>()
                {
                    new Package("VVI Product", new Guid("FBCD304A-ACC8-4F30-BF1E-D084256573A2")),
                    new Package("VVI Product", new Guid("FBCD304A-ACC8-4F30-BF1E-D084256573A2"))
                }
            };
        }
    }
}
