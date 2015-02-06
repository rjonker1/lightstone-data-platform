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
                var province = provinces.Select(x => x).Where(x => x.Name == "Gauteng");
                var provId = province.Select(x => x.Id).FirstOrNull().ToString();
                var provName = province.Select(x => x.Name).FirstOrNull().ToString();

                bus.Publish(new CreateCustomer(customerDto.CustomerName, customerDto.AccountOwnerName, customerDto.Province));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = customers });
            };

            Get["/Put/{id}"] = _ =>
            {
                return View["CustomerSave", new CustomerDto()];
            };

            Get["/Customers/{id}"] = _ =>
            {
                return View["CustomerSave", new CustomerDto()];
            };

            Get["/Customers/Create"] = _ =>
            {
                var province = provinces.Select(x => x).Where(x => x.Name == "Gauteng");
                var provId = province.Select(x => x.Id).FirstOrNull().ToString();
                var provName = province.Select(x => x.Name).FirstOrNull().ToString();

                bus.Publish(new CreateCustomer("Testeroonie Inc. Global", "Random account owner", new Province(new Guid(provId), provName)));

                return "Success!";
            };

            
        }
    }
}