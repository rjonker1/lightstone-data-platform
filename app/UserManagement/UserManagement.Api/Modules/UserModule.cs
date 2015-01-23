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
                    new UserType(new Guid("7AAA58C6-5632-442F-B63F-D985715163D7"), "User"),
                    new List<Role> { new Role(new Guid("42C4CF23-F9E7-4354-B0A8-FC611C38E5D3"), "Admin") },
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