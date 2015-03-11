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
    public class NamedEntityModule : NancyModule
    {
        public NamedEntityModule(IRetrieveEntitiesByType entityRetriever)
        {
            Get["/NamedEntities/{type}/{filter}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var valueEntities = entityRetriever.GetNamedEntities(type, parameters.filter);
                var dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(valueEntities);
                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };
        }
    }
}