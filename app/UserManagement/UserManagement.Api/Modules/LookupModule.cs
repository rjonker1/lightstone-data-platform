using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Api.Modules
{
    public class LookupModule : NancyModule
    {
        public LookupModule(IBus bus, IRetrieveEntitiesByType entityRetriever, INamedEntityRepository<NamedEntity> entities)
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

            Get["/Lookups/Add/{type}"] = parameters =>
            {
                return View["Save", new NamedEntityDto{AssemblyQualifiedName = parameters.type.ToString()}];
            };

            Post["/Lookups"] = _ =>
            {
                var dto = this.Bind<NamedEntityDto>();
                var entity = (NamedEntity)Mapper.Map(dto, entities.Get(dto.Id), typeof(NamedEntityDto), Type.GetType(dto.AssemblyQualifiedName));

                bus.Publish(new CreateUpdateEntity(entity, true));

                return Response.AsJson(dto.AssemblyQualifiedName);
            };

            Get["/Lookups/{id:guid}"] = parameters =>
            {
                var id = (Guid)parameters.id;
                var dto = Mapper.Map<NamedEntity, NamedEntityDto>(entities.First(x => x.Id == id)); //todo: repo.Get() not loading entity

                return View["Save", dto];
            };

            Post["/Lookups/{id}"] = _ =>
            {
                var dto = this.Bind<NamedEntityDto>();
                var namedEntity = entities.First(x => x.Id == dto.Id);
                var entity = (NamedEntity)Mapper.Map(dto, namedEntity, typeof(NamedEntityDto), namedEntity.GetType());

                bus.Publish(new CreateUpdateEntity(entity, false));

                return Response.AsJson(namedEntity.GetType().AssemblyQualifiedName);
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