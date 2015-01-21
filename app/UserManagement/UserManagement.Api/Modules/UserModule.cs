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
            Get["/User/Create"] = _ =>
            {
                var userTypeId = new Guid("B8BCBCC8-DDE0-4F10-B30C-606C07C99DA0");
                bus.Publish(new CreateUser(DateTime.Now, "APITestUser", DateTime.Now, "password", "username", userTypeId, true));

                return "Success!";
            };
        }
    }
}