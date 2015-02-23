using System;
using System.Collections.Generic;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.CommandHandlers.Contracts;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Contracts;
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

                bus.Publish(new CreateUpdateEntity(entity, true));

                return null;
            };

            Get["/Contracts/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Contract, ContractDto>(contracts.Get(guid));

                return View["Save", dto];
            };
            //todo: Get Sammy.js to work with Put route
            Post["/Contracts/{id}"] = _ =>
            {
                var dto = this.Bind<ContractDto>();
                var entity = Mapper.Map(dto, contracts.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity, false));

                return null;
            };

            Post["/Contracts/GetPackage"] = _ =>
            {
                var dto = this.Bind<ContractPackageRequestDto>();
                if (dto == null)
                    return Response.AsJson(new { });

                var handler = new GetContractPackageHandler(contracts);
                handler.Handle(new GetPackageOnContract(dto.ContractId));

                return Response.AsJson(handler.Response);
            };
        }
    }
}