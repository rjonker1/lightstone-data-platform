using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Customers;

namespace UserManagement.Api.Modules
{
    public class CustomerModule : NancyModule
    {

        public CustomerModule(IBus bus, IRepository<Customer> customers)
        {
            Get["/Customers"] = _ =>
            {

                bus.Publish(new CreateCustomer("Testeroonie Inc.", "Random account owner"));

                return "Success!";
            };
        }
    }
}