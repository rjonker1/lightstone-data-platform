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
    public class CustomerModule : NancyModule
    {
        public CustomerModule(IBus bus, IRepository<Customer> customers)
        {
            Get["/Customers"] = _ =>
            {
                var dto = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/Customers/Add"] = parameters =>
            {
                return View["Save", new CustomerDto()];
            };

            Post["/Customers"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = Mapper.Map(dto, customers.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity, true));

                return null;
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Customer, CustomerDto>(customers.Get(guid));

                return View["Save", dto];
            };
            //todo: Get Sammy.js to work with Put route
            Post["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = Mapper.Map(dto, customers.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity, false));

                return null;
            };
        }
    }
}