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
                    new UserType(new Guid("85484589-40DE-4B71-BF24-5FBC8537146C"), "User"),
                    new List<Role> { new Role(new Guid("B383C718-6E37-451A-B3C9-D22363219C12"), "Admin") },
                    username, surname, "IdNumber", "contactNumber");


            Get["/Users/Create"] = _ =>
            {
                bus.Publish(new CreateUser(dto.FirstCreateDate, dto.LastUpdateBy, dto.LastUpdateDate, dto.Password, dto.UserName, dto.IsActive, dto.UserType, 
                                            dto.Roles,
                                            dto.ContactNumber, dto.FirstName, dto.Surname, dto.IdNumber));

                return "Success!";
            };

            Get["/Users"] = _ =>
            {

                var random = users.AsEnumerable();
                var refined = random.Select(x => x).Where(x => x.IsActive == true);
                //var test = userRepository.Get(new Guid("74CB623E-A081-498F-A54C-58E7AC4182A8"));

                return Response.AsJson(refined);
            };

        }
    }
}