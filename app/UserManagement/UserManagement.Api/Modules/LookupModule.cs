using System;
using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class LookupModule : NancyModule
    {
        public LookupModule(IRetrieveEntitiesByType entityRetriever)
        {
            Get["/Lookups/{type}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = entityRetriever.GetNamedEntities(type) });
            };
        }
    }
}