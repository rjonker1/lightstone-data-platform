using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;
using IBus = MemBus.IBus;

namespace UserManagement.Api.Modules
{
    public class ClientModule : SecureModule
    {
        public ClientModule(IBus bus, IAdvancedBus eBus, IClientRepository clients)
        {
            Get["/Clients"] = _ =>
            {

                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<ClientDto>) Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
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

                ///RabbitMQ
                var client = Mapper.Map(dto, new Client());
                client.ClientAccountNumber.Client = entity;

                var metaEntity = Mapper.Map(client, new ClientMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

                return null;
            };

            Get["/Clients/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var client = clients.Get(guid);
                var dto = Mapper.Map<Client, ClientDto>(client);
                return View["Save", dto];
            };

            Put["/Clients/{id}"] = _ =>
            {
                var dto = this.Bind<ClientDto>();
                var entity = Mapper.Map(dto, clients.Get(dto.Id) ?? new Client());

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                ////RabbitMQ
                var metaEntity = Mapper.Map(entity, new ClientMessage());
                var advancedBus = new TransactionBus(eBus);
                advancedBus.SendDynamic(metaEntity);

                return null;
            };

            Delete["/Clients/{id}"] = _ =>
            {

                var dto = this.Bind<ClientDto>();
                var entity = clients.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Client has been soft deleted");
            };
        }
    }
}