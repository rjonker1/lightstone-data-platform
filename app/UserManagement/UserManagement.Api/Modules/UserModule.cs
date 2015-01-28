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
        public UserModule(IBus bus, IHandleMessages handler, IRepository<User> users, IRepository<Customer> customers, IRepository<Client> clients)
        {

            Get["/Users"] = _ =>
            {

                var random = users.AsEnumerable();
                var refined = random.Select(x => x).Where(x => x.IsActive == true);
                //var test = userRepository.Get(new Guid("74CB623E-A081-498F-A54C-58E7AC4182A8"));

                return Response.AsJson(refined);
            };

            Get["/Users/Create"] = _ =>
            {

                //Test params until front-end is established
                var username = "Johnny";
                var surname = "Testeroonie";

                var customerToLink = customers.Select(x => x).FirstOrDefault(x => x.CustomerName == "Testeroonie Inc. Global");
                var clientToLink = clients.Select(x => x).FirstOrDefault(x => x.ClientName == "Testeroonie Client");

                var dto = new UserDto(DateTime.Now, username, DateTime.Now, "password", "username", true,
                        new UserType(new Guid("505941EE-C0F7-4A32-AF85-BCEFD172E8FA"), "User"),
                        new Collection<Customer> { customerToLink },
                        new List<Client> { clientToLink },
                        new List<Role> { new Role(new Guid("CF1CC26F-2A00-4DB9-8483-27FEB3E254D8"), "Admin") },
                        username, surname, "IdNumber", "contactNumber");



                bus.Publish(new CreateUser(dto.FirstCreateDate, dto.LastUpdateBy, dto.LastUpdateDate, dto.Password, dto.UserName, dto.IsActive, dto.UserType, 
                                            dto.Customers,
                                            dto.Clients,
                                            dto.Roles,
                                            dto.ContactNumber, dto.FirstName, dto.Surname, dto.IdNumber));

                return "Success!";
            };

        }
    }
}