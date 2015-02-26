using System;
using System.Collections.Generic;
using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Dtos;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class LookupModule : NancyModule
    {
        public LookupModule(IRetrieveEntitiesByType entityRetriever)
        {
            Get["/Lookups/{type}"] = parameters =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var namedEntities = entityRetriever.GetNamedEntities(type, Context.Request.Query["search[value]"].Value,
                    model.Start, model.Length);
                var dto = (DataTablesViewModel)Mapper.Map<PagedList<NamedEntity>, DataTablesViewModel>(namedEntities, model);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), dto);
            };

            Get["/Lookups/{type}/{filter}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var namedEntities = entityRetriever.GetNamedEntities(type, parameters.filter);
                var dto = Mapper.Map<IEnumerable<NamedEntity>, IEnumerable<NamedEntityDto>>(namedEntities);
                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };
        }
    }
}