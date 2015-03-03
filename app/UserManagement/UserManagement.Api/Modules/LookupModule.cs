﻿using System;
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
        public LookupModule(IBus bus, IRetrieveEntitiesByType entityRetriever, IValueEntityRepository<ValueEntity> entities)
        {
            Get["/Lookups/{type}"] = parameters =>
            {
                var model = this.Bind<DataTablesViewModel>();
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var valueEntities = entityRetriever.GetValueEntities(type, Context.Request.Query["search[value]"].Value,
                    model.Start, model.Length);
                var dto = (DataTablesViewModel)Mapper.Map<PagedList<ValueEntity>, DataTablesViewModel>(valueEntities, model);

                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), dto);
            };

            Get["/Lookups/Add/{type}"] = parameters =>
            {
                return View["Save", new ValueEntityDto { AssemblyQualifiedName = parameters.type.ToString() }];
            };

            Post["/Lookups"] = _ =>
            {
                var dto = this.Bind<ValueEntityDto>();
                var entity = (ValueEntity)Mapper.Map(dto, null, typeof(ValueEntityDto), Type.GetType(dto.AssemblyQualifiedName));

                bus.Publish(new CreateUpdateEntity(entity, "Read"));

                return Response.AsJson(dto.AssemblyQualifiedName);
            };

            Get["/Lookups/{id:guid}"] = parameters =>
            {
                var id = (Guid)parameters.id;
                var valueEntity = entities.First(x => x.Id == id);
                var dto = Mapper.Map(valueEntity, new ValueEntityDto(), valueEntity.GetType(), typeof(ValueEntityDto)); //todo: repo.Get() not loading entity

                return View["Save", dto];
            };

            Post["/Lookups/{id}"] = _ =>
            {
                var dto = this.Bind<ValueEntityDto>();
                var valueEntity = entities.First(x => x.Id == dto.Id);
                var entity = (ValueEntity)Mapper.Map(dto, valueEntity, typeof(ValueEntityDto), valueEntity.GetType());

                bus.Publish(new CreateUpdateEntity(entity, "Create"));

                return Response.AsJson(valueEntity.GetType().AssemblyQualifiedName);
            };

            Get["/Lookups/{type}/{filter}"] = parameters =>
            {
                var typeName = parameters.type.ToString();
                var type = Type.GetType(typeName);
                var valueEntities = entityRetriever.GetValueEntities(type, parameters.filter);
                var dto = Mapper.Map<IEnumerable<ValueEntity>, IEnumerable<ValueEntityDto>>(valueEntities);
                return Negotiate
                    .WithView("Index")
                    .WithModel(new LookupViewModel(type))
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { dto });
            };
        }
    }
}