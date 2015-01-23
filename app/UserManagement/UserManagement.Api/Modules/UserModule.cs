using System;
using System.Collections.Generic;
using System.Linq;
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
        public UserModule(IBus bus, IHandleMessages handler, IRepository<User> users )
        {

            //Test params until front-end is established
            var username = "Johnny";
            var surname = "Testeroonie";

            var dto = new UserDto(DateTime.Now, username, DateTime.Now, "password", "username", true,
                    new UserType(new Guid("8371A39B-0595-43EF-A519-C2E8C0298075"), "User"),
                    new List<Role> { new Role(new Guid("60ABB4FA-4654-4FE2-9B4A-7FC6282B5094"), "Admin") },
                    username, surname, "IdNumber", "contactNumber");


            Get["/User/Create"] = _ =>
            {
                bus.Publish(new CreateUser(dto.FirstCreateDate, dto.LastUpdateBy, dto.LastUpdateDate, dto.Password, dto.UserName, dto.IsActive, dto.UserType, 
                                            dto.Roles, dto.FirstName, dto.Surname, dto.IdNumber, dto.ContactNumber));

                return "Success!";
            };

            Get["/User"] = _ =>
            {

                var random = users.AsEnumerable();
                var refined = random.Select(x => x).Where(x => x.IsActive == false);
                //var test = userRepository.Get(new Guid("74CB623E-A081-498F-A54C-58E7AC4182A8"));

                return Response.AsJson(refined);
            };

        }
    }
}