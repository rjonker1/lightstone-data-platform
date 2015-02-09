using System;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Customers;

namespace UserManagement.Api.Modules
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule(IBus bus, IRepository<Customer> customers, IRepository<CommercialState> commercialStates, IRepository<CreateSource> createSources, IRepository<PlatformStatus> platformStatuses)
        {
            Get["/Customers"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Post["/Customers"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var commercialState = commercialStates.Get(dto.CommercialStateId);
                var createSource = createSources.Get(dto.CreateSourceId);
                var platformStatus = platformStatuses.Get(dto.PlatformStatusId);

                bus.Publish(new CreateUpdateCustomer(dto.CustomerName, dto.AccountOwnerName, commercialState, createSource, platformStatus));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Get["/Customers/Add"] = parameters =>
            {
                return View["Save", new CustomerDto()];
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var customer = customers.Get(guid);
                var dto = Mapper.Map<Customer, CustomerDto>(customer);
                return View["Save", dto];
            };

            Put["/Customers/{id}"] = _ =>
            {
                var dto = this.Bind<CustomerDto>();
                var commercialState = commercialStates.Get(dto.CommercialStateId);
                var createSource = createSources.Get(dto.CreateSourceId);
                var platformStatus = platformStatuses.Get(dto.PlatformStatusId);

                bus.Publish(new CreateUpdateCustomer(dto.Id, dto.CustomerName, dto.AccountOwnerName, commercialState, createSource, platformStatus));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };
        }
    }
}