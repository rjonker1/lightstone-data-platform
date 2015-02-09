using System;
using System.Linq;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using NHibernate.Util;
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
                var province = provinces.FirstOrDefault(x => x.Id == customerDto.Id);

                bus.Publish(new CreateUpdateCustomer(customerDto.CustomerName, customerDto.AccountOwnerName, province));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Get["/Customers/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;

                var customer = customers.FirstOrDefault(x => x.Id == guid);
                return View["CustomerSave", new CustomerDto{Id= customer.Id, CustomerName = customer.CustomerName, AccountOwnerName = customer.AccountOwnerName}];
            };

            Put["/Customers/{id}"] = _ =>
            {
                var model = this.Bind<CustomerDto>();
                var province = provinces.FirstOrDefault(x => x.Id == model.Id);

                bus.Publish(new CreateUpdateCustomer(model.Id, model.CustomerName, model.AccountOwnerName, province));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };
        }
    }
}