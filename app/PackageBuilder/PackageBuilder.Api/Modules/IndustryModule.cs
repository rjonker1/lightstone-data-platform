using System;
using MemBus;
using Nancy;
using PackageBuilder.Api.Helpers.Extensions;
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

            Post["/Industry/Add"] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.name.Value == null)
                    return Response.AsJson(new { response = "Failure!" });

                bus.Publish(new CreateIndustry(Guid.NewGuid(), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };

            Post["/Industry/Edit"] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    return Response.AsJson(new { response = "Failure!" });
                    
                bus.Publish(new RenameIndustry(new Guid(model.id.Value), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}