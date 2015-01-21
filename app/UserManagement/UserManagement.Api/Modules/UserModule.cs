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
                var userTypeId = new Guid("DAA5B0FF-CC61-400D-8018-FE94C8548562");
                bus.Publish(new CreateUser(DateTime.Now, "APITestUser", DateTime.Now, "password", "username", userTypeId, true));

                return "Success!";
            };
        }
    }
}