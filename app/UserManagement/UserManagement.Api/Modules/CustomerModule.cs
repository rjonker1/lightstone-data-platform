using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class CustomerModule : SecureModule
    {
        public CustomerModule(IBus bus, ICustomerRepository customers)
        {
            Get["/Customers"] = _ =>
            {
                var search = Context.Request.Query["search"];
                var offset = Context.Request.Query["offset"];
                var limit = Context.Request.Query["limit"];

                if (offset == null) offset = 0;
                if (limit == null) limit = 10;

                var model = this.Bind<DataTablesViewModel>();
                var dto = (IEnumerable<CustomerDto>)Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);//.Search(Context.Request.Query["search[value]"].Value, model.Start, model.Length));
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto.ToList() });
            };

            Get["/Customers/Add"] = parameters => View["Save", new CustomerDto()];

            Post["/Customers"] = _ =>
            {
                var dto = this.BindAndValidate<CustomerDto>();

                if (ModelValidationResult.IsValid)
                {
                    var entity = Mapper.Map(dto, customers.Get(dto.Id));
                    bus.Publish(new CreateUpdateEntity(entity, "Create"));

                    return View["Index"];
                }

                return View["Save", dto];
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var dto = Mapper.Map<Customer, CustomerDto>(customers.Get(guid));

                return View["Save", dto];
            };

            Put["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = Mapper.Map(dto, customers.Get(dto.Id));

                bus.Publish(new CreateUpdateEntity(entity, "Update"));

                return null;
            };

            Delete["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var entity = customers.Get(dto.Id);

                bus.Publish(new SoftDeleteEntity(entity));

                return Response.AsJson("Customer has been soft deleted");
            };
        }
    }
}