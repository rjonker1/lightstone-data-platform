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
        public CustomerModule(IBus bus, IRepository<Customer> customers, IRepository<Province> provinces)
        {
            Get["/Customers"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Post["/Customers"] = _ =>
            {
                var customerDto = this.Bind<CustomerDto>();
                var province = provinces.Get(customerDto.ProvinceId);

                bus.Publish(new CreateUpdateCustomer(customerDto.CustomerName, customerDto.AccountOwnerName, province));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Get["/Customers/Add"] = parameters =>
            {
                return View["CustomerSave", new CustomerDto()];
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var customer = customers.Get(guid);
                var dto = Mapper.Map<Customer, CustomerDto>(customer);
                return View["CustomerSave", dto];
            };

            Put["/Customers/{id}"] = _ =>
            {
                var customerDto = this.Bind<CustomerDto>();
                var province = provinces.Get(customerDto.ProvinceId);

                bus.Publish(new CreateUpdateCustomer(customerDto.Id, customerDto.CustomerName, customerDto.AccountOwnerName, province));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };
        }
    }
}