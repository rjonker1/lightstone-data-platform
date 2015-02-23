using System;
using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.ExceptionHandling;
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
    public class ClientModule : NancyModule
    {
        public ClientModule(IBus bus, IRepository<Client> clients)
        {
            Get["/Clients"] = _ =>
            {
                var dto = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/Clients/Add"] = parameters =>
            {
                return View["Save", new ClientDto()];
            };

            Post["/Clients"] = _ =>
            {
                var dto = this.Bind<ClientDto>();
                var entity = Mapper.Map(dto, clients.Get(dto.Id) ?? new Client());

                bus.Publish(new CreateUpdateEntity(entity, true));

                return null;
            };

            Get["/Clients/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var client = clients.Get(guid);
                var dto = Mapper.Map<Client, ClientDto>(client);
                return View["Save", dto];
            };

            Post["/Clients/{id}"] = _ =>
            {
                var dto = this.Bind<ClientDto>();
                var entity = Mapper.Map(dto, clients.Get(dto.Id) ?? new Client());

                bus.Publish(new CreateUpdateEntity(entity, false));

                return null;
            };
        }
    }
}