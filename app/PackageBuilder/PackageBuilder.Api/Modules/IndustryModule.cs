using System;
using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class IndustryModule : NancyModule
    {
        public IndustryModule(IPublishStorableCommands publisher, IRepository<Industry> repository)
        {
            const string industriesRoute = "/Industries";

            Get[industriesRoute] = parameters => 
                Response.AsJson(repository);

            Post[industriesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.name.Value == null)
                    throw new LightstoneAutoException("Could not bind 'Name' value");

                publisher.Publish(new CreateIndustry(Guid.NewGuid(), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };

            Put[industriesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    throw new LightstoneAutoException("Could not bind 'id' or 'Name' value");
                    
                publisher.Publish(new RenameIndustry(new Guid(model.id.Value), model.name.Value, false));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}