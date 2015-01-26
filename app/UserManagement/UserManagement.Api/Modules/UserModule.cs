using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public UserModule(IBus bus, IHandleMessages handler, IRepository<User> users, IRepository<Customer> customers)
        {

            Get["/Users/Create"] = _ =>
            {

                //Test params until front-end is established
                var username = "Johnny";
                var surname = "Testeroonie";

                var customerToLink = customers.Select(x => x).FirstOrDefault(x => x.CustomerName == "Testeroonie Inc. Global");

                var dto = new UserDto(DateTime.Now, username, DateTime.Now, "password", "username", true,
                        new UserType(new Guid("CD39D5F5-F635-4604-B527-B606D8773E32"), "User"),
                        new Collection<Customer> { customerToLink },
                        //new Customer(new Guid("F035280D-0631-42CC-BE79-32A0A113D58F"), "", "", new Province(new Guid("9219B776-B5DC-4884-A3BA-3A566A73DF9B"), "Gauteng"))
                        new List<Role> { new Role(new Guid("C9A865F0-DBC7-47E7-B07D-383284E03633"), "Admin") },
                        username, surname, "IdNumber", "contactNumber");



                bus.Publish(new CreateUser(dto.FirstCreateDate, dto.LastUpdateBy, dto.LastUpdateDate, dto.Password, dto.UserName, dto.IsActive, dto.UserType, 
                                            dto.Customers,
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