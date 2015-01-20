using System;
using Nancy;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule()
        {
            Get["/User"] = _ =>
            {
                var create = new CreateUser(DateTime.Now, "test", DateTime.Now, "password", "username", new Guid(), true);

                return null;
            };
        }
    }
}