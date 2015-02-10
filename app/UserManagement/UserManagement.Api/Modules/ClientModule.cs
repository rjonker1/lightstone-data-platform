﻿using System;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Clients;

namespace UserManagement.Api.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IBus bus, IRepository<Client> clients)
        {
            Get["/Clients"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = clients });
            };

            Get["/Clients/Add"] = parameters =>
            {
                return View["Save", new ClientDto()];
            };

            Post["/Clients"] = _ =>
            {
                var dto = this.Bind<ClientDto>();
                bus.Publish(new CreateUpdateClient(dto.ClientName));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = clients });
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
                bus.Publish(new CreateUpdateClient(dto.Id, dto.ClientName));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = clients });
            };
        }
    }
}