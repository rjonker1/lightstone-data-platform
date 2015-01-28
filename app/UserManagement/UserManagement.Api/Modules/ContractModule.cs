using System;
using System.Linq;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Contracts;

namespace UserManagement.Api.Modules
{
    public class ContractModule : NancyModule
    {
        public ContractModule(IBus bus, IRepository<Contract> contracts, IRepository<ContractDuration> contractDurations, IRepository<ContractType> contractTypes,
                                        IRepository<EscalationType> escalationTypes, IRepository<Client> clients)
        {

            Get["/Contracts"] = _ =>
            {

                return Response.AsJson(contracts.Select(x => x));
            };

            Get["/Contracts/Create"] = _ =>
            {

                var contractDuration = contractDurations.Select(x => x).FirstOrDefault(x => x.Name == "Rolling MoM");
                var contractType = contractTypes.Select(x => x).FirstOrDefault(x => x.Name == "Online Agreement");
                var esalationType = escalationTypes.Select(x => x).FirstOrDefault(x => x.Name == "Annual % per product");
                var client = clients.Select(x => x).FirstOrDefault(x => x.ClientName == "Testeroonie Client");

                var dto = new ContractDto(DateTime.Now, contractDuration.Id, "New Contract", contractType.Id,
                    esalationType.Id, "Testeroonie", DateTime.Now, null, "This is a legit test contract", "Contract entering user", DateTime.Now, null, "Contract 1", "132",
                    client, contractType, esalationType, contractDuration);

                bus.Publish(new CreateContract(dto.ContractCommencementDate, dto.ContractDurationId, dto.ContractName,
                    dto.ContractTypeId, dto.EscalationTypeId, dto.LastUpdateBy,
                    dto.LastUpdateDate, dto.ClientId, dto.ContactDetail, dto.EnteredIntoBy, dto.OnlineAcceptance,
                    dto.ProfileDetailId, dto.RegisteredName,
                    dto.RegistrationNumber, dto.Client, dto.ContractType, dto.EscalationType, dto.ContractDuration));

                return "Success";
            };
        }
    }
}