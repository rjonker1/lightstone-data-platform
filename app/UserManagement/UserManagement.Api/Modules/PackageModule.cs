using System;
using System.Collections.Generic;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IRepository<Package> packages, IPackageBuilderApiClient packageBuilderApi)
        {
            Get["/Packages"] = _ =>
            {
                var packageResponse = packageBuilderApi.Get("", "Packages");
                var dto = Mapper.Map<IEnumerable<Package>, IEnumerable<PackageDto>>(packages);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
            };

            Get["/Packages/Add"] = parameters =>
            {
                return View["Save", new PackageDto()];
            };

            Post["/Packages"] = _ =>
            {
                var dto = this.Bind<PackageDto>();
                var entity = Mapper.Map(dto, packages.Get(dto.Id) ?? new Package());

                bus.Publish(new CreateUpdateEntity(entity));

                return Response.AsJson("Test");
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = packages });
            };

            Get["/Packages/{id}"] = parameters =>
            {
                var guid = (Guid)parameters.id;
                var entity = packages.Get(guid);
                var dto = Mapper.Map<Package, PackageDto>(entity);
                return View["Save", dto];
            };

            Post["/Packages/{id}"] = _ =>
            {
                var dto = this.Bind<PackageDto>();
                var entity = Mapper.Map(dto, packages.Get(dto.Id) ?? new Package());

                bus.Publish(new CreateUpdateEntity(entity));

                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = packages });
            };
        }
    }
}