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
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IRepository<User> users)
        {
            Get["/Users"] = _ =>
            {
                var dto = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
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

                return null;
            };

            Get["/Users/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<User, UserDto>(users.Get(guid));

                return View["Save", dto];
            };

            Post["/Users/{id}"] = _ =>
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
                var entity = Mapper.Map(dto, users.Get(dto.Id));

                bus.Publish(new SoftDeleteEntity(entity, "Delete"));

                return Response.AsJson("User has been soft deleted");
            };
        }
    }
}