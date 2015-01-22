using System;
using System.Collections.Generic;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IHandleMessages handler)
        {
            Get["/User/Create"] = _ =>
            {

                bus.Publish(new CreateUser(DateTime.Now, "User1", DateTime.Now, "password", "username", true,
                    new UserType(new Guid("F54BCB36-AEB6-40A9-9AD3-9E54AF799AE9"), "User"),
                    //new List<Role> { role.AssignUserRole((new Guid("c628ba87-bab5-44a1-98f8-16ec5c560f85")), "Admin") }));
                    new List<Role> { new Role(new Guid("c69bfbd5-be90-401b-b2b1-4c5147aefa17"), "Admin") }));

                return "Success!";
            };

            Get["/User/Profile"] = _ =>
            {

                return "Success";
            };
        }
    }
}