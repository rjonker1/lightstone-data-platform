using System;
using System.Collections.Generic;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Entities.Commands.UserProfiles;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IHandleMessages handler, IRepository<User> userRepository )
        {

            var username = "Johnny";
            var surname = "Testeroonie";


            Get["/User/Create"] = _ =>
            {
              
                bus.Publish(new CreateUser(DateTime.Now, username, DateTime.Now, "password", "username", true,
                    new UserType(new Guid("5e72ef30-a675-4af7-bce8-1e801a580bf3"), "User"),
                    //new List<Role> { role.AssignUserRole((new Guid("c628ba87-bab5-44a1-98f8-16ec5c560f85")), "Admin") }));
                    new List<Role> { new Role(new Guid("a0f7e94b-c469-45b5-a76b-129e3b0d926b"), "Admin") }));

                return "Success!";
            };

            Get["/User/Profile"] = _ =>
            {
                //Profile setup

                bus.Publish(new CreateUserProfile("123456789", username, "1234567891234", surname,
                    userRepository.Get(new Guid("162C3AF3-230F-4B6D-9062-E7D22F4E427E"))));

                return "Profile created!";
            };
        }
    }
}