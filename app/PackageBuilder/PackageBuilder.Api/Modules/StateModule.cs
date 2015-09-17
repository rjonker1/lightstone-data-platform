using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using Nancy;
using Nancy.Security;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.Read;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class StateModule : SecureModule
    {
        public StateModule(IPublishStorableCommands publisher, IRepository<State> repository)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString() });

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