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
    public class CustomerModule : NancyModule
    {
        public CustomerModule(IBus bus, ICustomerRepository customers)
        {
            Get["/Customers"] = _ =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<CustomerDto>)Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
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