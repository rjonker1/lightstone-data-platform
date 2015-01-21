using System;
using MemBus;
using Nancy;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus)
        {
            Get["/User"] = _ =>
            {
                var userTypeId = new Guid("A46A4CFE-2A7E-43C0-98C0-0B9E673E6107");
                bus.Publish(new CreateUser(DateTime.Now, "APITestUser", DateTime.Now, "password", "username", userTypeId, true));

                return "Success!";
            };
        }
    }
}