using System;
using System.Collections.Generic;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Api.Modules
{
    public class ContractModule : NancyModule
    {
        public ContractModule(IBus bus, IRepository<Contract> contracts)
        {
            Get["/Contracts"] = _ =>
            {
                var dto = Mapper.Map<IEnumerable<Contract>, IEnumerable<ContractDto>>(contracts);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/Contracts/Add"] = parameters =>
            {
                return View["Save", new ContractDto()];
            };

            Post["/Contracts"] = _ =>
            {
                var dto = this.Bind<ContractDto>();
                var entity = Mapper.Map(dto, contracts.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return null;
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = contracts });
            };

            Get["/Contracts/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Contract, ContractDto>(contracts.Get(guid));
                //dto.BillingDto = dto.BillingDto ?? new BillingDto();

                return View["Save", dto];
            };
            //todo: Get Sammy.js to work with Put route
            Post["/Contracts/{id}"] = _ =>
            {
                var dto = this.Bind<ContractDto>();
                var entity = Mapper.Map(dto, contracts.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return null;
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = contracts });
            };

            //Post["/Contracts/GetPackage"] = _ =>
            //{
            //    var dto = this.Bind<ContractPackageRequestDto>();
            //    if (dto == null)
            //        return Response.AsJson(new {});

            //    var handler = new GetContractPackageHandler(contracts);
            //    handler.Handle(new GetPackageOnContract(dto.ContractId));
            //    return Response.AsJson(handler.Response);
            //};

            //Get["/Contracts/Create"] = _ =>
            //{

            //    var contractDuration = contractDurations.Select(x => x).FirstOrDefault(x => x.Name == "Rolling MoM");
            //    var contractType = contractTypes.Select(x => x).FirstOrDefault(x => x.Name == "Online Agreement");
            //    var esalationType = escalationTypes.Select(x => x).FirstOrDefault(x => x.Name == "Annual % per product");
            //    var client = clients.Select(x => x).FirstOrDefault(x => x.Name == "Testeroonie Client");

            //    var dto = new ContractDto(DateTime.Now, contractDuration.Id, "New Contract", contractType.Id,
            //        esalationType.Id, "Testeroonie", DateTime.Now, null, "This is a legit test contract", "Contract entering user", DateTime.Now, null, "Contract 1", "132",
            //        client, contractType, esalationType, contractDuration);

            //    bus.Publish(new CreateContract(dto.ContractCommencementDate, dto.ContractDurationId, dto.Name,
            //        dto.ContractTypeId, dto.EscalationTypeId, dto.LastUpdateBy,
            //        dto.LastUpdateDate, dto.ClientId, dto.Description, dto.EnteredIntoBy, dto.OnlineAcceptance,
            //        dto.ProfileDetailId, dto.RegisteredName,
            //        dto.RegistrationNumber, dto.Client, dto.ContractType, dto.EscalationType, dto.ContractDuration));

            //    return "Success";
            //};
        }
    }
}