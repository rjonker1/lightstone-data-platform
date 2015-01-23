using System;
using System.Collections.Generic;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IHandleMessages handler, IRepository<User> userRepository )
        {

            //Test params until front-end is established
            var username = "Johnny";
            var surname = "Testeroonie";

            var dto = new UserDto(DateTime.Now, username, DateTime.Now, "password", "username", true,
                    new UserType(new Guid("5e72ef30-a675-4af7-bce8-1e801a580bf3"), "User"),
                    new List<Role> { new Role(new Guid("a0f7e94b-c469-45b5-a76b-129e3b0d926b"), "Admin") },
                    username, surname, "IdNumber", "contactNumber");


            Get["/User/Create"] = _ =>
            {
                bus.Publish(new CreateUser(dto.FirstCreateDate, dto.LastUpdateBy, dto.LastUpdateDate, dto.Password, dto.UserName, dto.IsActive, dto.UserType, 
                                            dto.Roles, dto.FirstName, dto.Surname, dto.IdNumber, dto.ContactNumber));

                return "Success!";
            };

        }
    }
}