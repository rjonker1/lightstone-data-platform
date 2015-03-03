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
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IUserRepository users)
        {
            Get["/Users"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<UserDto>)Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
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
                var entity = users.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("User has been soft deleted");
            };
        }
    }
}