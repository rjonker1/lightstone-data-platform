using System;
using System.Collections.Generic;
using AutoMapper;
using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Dtos;
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
                var dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(namedEntities);
                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };
        }
    }
}