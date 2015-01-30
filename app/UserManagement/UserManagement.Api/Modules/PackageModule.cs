using System;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Packages;

namespace UserManagement.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IRepository<Package> packages)
        {

            Get["/Packages"] = _ => Response.AsJson(packages);

            Get["/Packages/Create"] = _ =>
            {

                bus.Publish(new CreatePackage("test", DateTime.Now, "Package 1", "1", true));

                return "Success";
            };
        }
    }
}