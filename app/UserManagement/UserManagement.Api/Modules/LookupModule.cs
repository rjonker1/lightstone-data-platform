using System;
using System.Linq;
using FluentNHibernate.Utils;
using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class LookupModule : NancyModule
    {
        private readonly IRetrieveEntitiesByType _entityRetriever;
        public LookupModule(IRetrieveEntitiesByType entityRetriever)
        {
            _entityRetriever = entityRetriever;

            Get["/Lookups/{type}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = _entityRetriever.GetNamedEntities(type) });
            };

            Get["/Lookups/{type}/{filter}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var namedEntities = _entityRetriever.GetNamedEntities(type, parameters.filter);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { namedEntities });
            };
        }

        //public IQueryable<NamedEntity> GetNamedEntities(Type type)
        //{
        //    var namedEntities = _entityRetriever.GetNamedEntities(type);
        //    return namedEntities.Where(x =);
        //}
    }
}