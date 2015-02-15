using System.Collections.Generic;
using System.Linq;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Api.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IBus bus, IRepository<User> users, IRepository<Customer> customers, IRepository<Client> clients)
        {
            Get["/Users"] = _ =>
            {
                var random = users.AsEnumerable();
                var refined = random.Select(x => x).Where(x => x.IsActive == true);

                return Response.AsJson(refined);
            };

            Get["/Users/Create"] = _ =>
            {
                var dto = new UserDto("Johnny", "Testeroonie", "IdNumber", "contactNumber", "username", "password", true, new UserType("User"), new HashSet<Role> { new Role("Admin") });

                bus.Publish(new CreateUser(dto.FirstName, dto.LastName, dto.IdNumber, dto.ContactNumber, dto.UserName, dto.Password, dto.IsActive, dto.UserType, dto.Roles));

                return "Success!";
            };
        }
    }
}