using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Repositories;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.Messaging.Billing.Messages;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, EasyNetQ.IBus eBus, IUserRepository users)
        {
            Get["/Users/All"] = _ => Response.AsJson(Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users));

            Get["/Users"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<UserDto>) Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/Users/Add"] = _ =>
            {
                return View["Save", new UserDto()];
            };

            Post["/Users"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var clientUsersDto = this.Bind<List<ClientUserDto>>();
                dto.ClientUsers = clientUsersDto;

                var entity = Mapper.Map(dto, users.Get(dto.Id) ?? new User());

                bus.Publish(new CreateUpdateEntity(entity, "Create"));

                //RabbitMQ
                var metaEntity = Mapper.Map(entity, new UserMessage());
                eBus.Publish(metaEntity);

                return null;
            };

            Get["/Users/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<User, UserDto>(users.Get(guid));

                return View["Save", dto];
            };

            Put["/Users/{id}"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var clientUsersDto = this.Bind<List<ClientUserDto>>();
                dto.ClientUsers = clientUsersDto;

                var entity = Mapper.Map(dto, users.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return null;
            };

            Delete["/Users/{id}"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var entity = users.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("User has been soft deleted");
            };
        }
    }
}