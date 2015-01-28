using System;
using System.Linq;
using MemBus;
using Nancy;
using NHibernate.Util;
using UserManagement.Domain.Core.Repositories;
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
                return Response.AsJson(customers);
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