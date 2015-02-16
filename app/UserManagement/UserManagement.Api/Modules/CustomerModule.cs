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
                return View["Save", new CustomerDto { BillingDto = new BillingDto() }];
            };

            Post["/Customers"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = Mapper.Map(dto, customers.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return null;
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Customer, CustomerDto>(customers.Get(guid));
                dto.BillingDto = dto.BillingDto ?? new BillingDto();

                return View["Save", dto];
            };
            //todo: Get Sammy.js to work with Put route
            Post["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = Mapper.Map(dto, customers.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity));

                return null;
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };
        }
    }
}