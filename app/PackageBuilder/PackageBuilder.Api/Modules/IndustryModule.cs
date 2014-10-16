using System;
using MemBus;
using Nancy;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using Raven.Client;

namespace PackageBuilder.Api.Modules
{
    public class IndustryModule : NancyModule
    {
        public IndustryModule(IBus bus, IDocumentSession session)
        {
            Get["/Industry"] = parameters =>
            {
                return Response.AsJson(session.Query<Industry>());
            };

            Get["/Industry/Add"] = parameters =>
            {
                var command = new CreateIndustry(Guid.NewGuid(), "Test industry");

                bus.Publish(command);

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