using System;
using System.Collections.Generic;
using MemBus;
using Nancy;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus)
        {
            Get["/User/Create"] = _ =>
            {
                bus.Publish(new CreateUser(DateTime.Now, "APITestUser1", DateTime.Now, "password", "username", true,
                    new UserType(new Guid("D0AC08B8-1D35-437B-9C72-B8341C13C20C"), "User"),
                    new List<Role> { new Role(new Guid("c628ba87-bab5-44a1-98f8-16ec5c560f85"), "Admin") }));

                return "Success!";
            };
        }
    }
}