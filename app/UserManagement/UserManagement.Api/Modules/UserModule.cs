using System;
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
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = users });
            };

            Get["/Users/Add"] = _ =>
            {
                return View["Save", new UserDto()];
            };

            Post["/Users"] = _ =>
            {
                var dto = this.Bind<UserDto>();
                var entity = Mapper.Map(dto, users.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = users });
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
                var entity = Mapper.Map<UserDto, User>(dto, users.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = users });
            };
        }
    }
}