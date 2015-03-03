using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IBus bus, IClientRepository clients)
        {
            Get["/Clients"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<ClientDto>)Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/Clients/Add"] = parameters =>
            {
                return View["Save", new ClientDto()];
            };

            Post["/Clients"] = _ =>
            {
                var dto = this.Bind<ClientDto>();
                var entity = Mapper.Map(dto, clients.Get(dto.Id) ?? new Client());

                bus.Publish(new CreateUpdateEntity(entity, "Create"));

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

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return null;
            };

            Delete["/Clients/{id}"] = _ =>
            {

                var dto = this.Bind<ClientDto>();
                var entity = clients.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity, "Delete"));

                return Response.AsJson("Client has been soft deleted");
            };
        }
    }
}