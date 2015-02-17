using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities.Commands.Contracts;

namespace UserManagement.Domain.CommandHandlers.Contracts
{
    //public class GetContractPackageHandler : AbstractMessageHandler<GetPackageOnContract>
    //{
    //    public ContractPackageResponseDto Response { get; private set; }
    //    private readonly IRepository<Contract> _repository;

    //    public GetContractPackageHandler(IRepository<Contract> repository)
    //    {
    //        _repository = repository;
    //    }

    //    public override void Handle(GetPackageOnContract command)
    //    {
    //        //TDOD: Impleent once contract information is in the database
    //        //var response = _repository.Get(command.ContractId);
    //        var response = FakeContract(command.ContractId);

    //        Response = response == null
    //            ? new ContractPackageResponseDto()
    //            : new ContractPackageResponseDto(response.Id,
    //                response.Packages.Where(w => w.IsActivated.HasValue && w.IsActivated.Value)
    //                    .OrderByDescending(o => o.Version)
    //                    .FirstOrDefault());
    //    }

    //    private static Contract FakeContract(Guid contractId)
    //    {
    //        return new Contract(contractId, DateTime.Now, "VVI Product", null, null, null, null, null, null, null, null, null)
    //        {
    //            Id = contractId,
    //            Packages = new List<Package>()
    //            {
    //                new Package("Vvi Package","1",true,new Guid("C2FB758F-B313-448B-9B19-9AC893DEFE3F")),
    //                new Package("Vvi Package","2",true,new Guid("C2FB758F-B313-448B-9B19-9AC893DEFE3F"))
    //            }
    //        };
    //    }
    //}
}
