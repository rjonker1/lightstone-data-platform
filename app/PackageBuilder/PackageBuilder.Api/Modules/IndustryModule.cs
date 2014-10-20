using System;
using MemBus;
using Nancy;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class IndustryModule : NancyModule
    {
        public IndustryModule(IBus bus, IRepository<Industry> repository)
        {
            Get["/Industry"] = parameters =>
            {
                return Response.AsJson(repository);
            };

            Get["/Industry/Add"] = parameters =>
            {
                var command = new CreateIndustry(Guid.NewGuid(), "Test industry");
                repository.Save(new Industry(Guid.NewGuid(), "Test"));
                //bus.Publish(command);

                return Response.AsJson("Success!");
            };

            Get["/Industry/Edit/{id}"] = parameters =>
            {
                bus.Publish(new RenameIndustry(new Guid(parameters.id), "Test1"));

                return Response.AsJson("Success!");
            };
        }
    }
}