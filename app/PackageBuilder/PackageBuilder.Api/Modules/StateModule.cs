using System;
using MemBus;
using Nancy;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class StateModule : NancyModule
    {
        public StateModule(IBus bus, IRepository<State> repository)
        {
            Get["/State"] = parameters =>
            {
                return Response.AsJson(repository);
            };

            Post["/State/Add"] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.name.Value == null)
                    return Response.AsJson(new { response = "Failure!" });

                bus.Publish(new CreateState(Guid.NewGuid(), model.name.Value));

                return Response.AsJson(new { response = "Success!" });
            };

            Post["/State/Edit"] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    return Response.AsJson(new { response = "Failure!" });
                    
                bus.Publish(new RenameState(new Guid(model.id.Value), model.name.Value));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}