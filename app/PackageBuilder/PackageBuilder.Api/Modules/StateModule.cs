using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Api.Modules
{
    public class StateModule : NancyModule
    {
        public StateModule(IPublishStorableCommands publisher, IRepository<State> repository)
        {
            const string statesRoute = "/States";

            Get[statesRoute] = parameters =>
                Response.AsJson(repository.Select(x => new { id = x.Id, name = x.Name.ToString(), alias = x.Alias }));

            Put[statesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    throw new LightstoneAutoException("Could not bind 'id' or 'Name' value");

                publisher.Publish(new RenameState(new Guid(model.id.Value), Enum.Parse(typeof(StateName), model.name.Value, true), model.alias.Value));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}