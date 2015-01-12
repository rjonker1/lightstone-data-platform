using System;
using System.Linq;
using MemBus;
using Nancy;
using PackageBuilder.Api.Helpers.Extensions;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class StateModule : NancyModule
    {
        public StateModule(IBus bus, IRepository<State> repository)
        {
            const string statesRoute = "/States";

            Get[statesRoute] = parameters => 
                Response.AsJson(repository.Select(x => new { id = x.Id, name = x.Name.ToString(), alias = x.Alias }));

            Put[statesRoute] = parameters =>
            {
                var model = Request.Body<dynamic>();
                if (model.id.Value == null && model.name.Value == null)
                    return Response.AsJson(new { response = "Failure!" });

                bus.Publish(new RenameState(new Guid(model.id.Value), Enum.Parse(typeof(StateName), model.name.Value, true), model.alias.Value));

                return Response.AsJson(new { response = "Success!" });
            };
        }
    }
}