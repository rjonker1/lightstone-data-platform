using System.Collections.Generic;
using AutoMapper;
using Nancy;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api;
using Shared.BuildingBlocks.Api.ApiClients;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IPackageBuilderApiClient packageBuilderApi)
        {
            Get["/Packages/{filter}"] = parameters =>
            {
                var packagesJson = packageBuilderApi.Get("", "Packages", new { filter = parameters.filter });
                var packages = JsonConvert.DeserializeObject<IEnumerable<PackageDto>>(packagesJson);
                //var dto = Mapper.Map<IEnumerable<PackageBuilder.Domain.Entities.Packages.ReadModels.Package>, IEnumerable<PackageDto>>(packages);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), packages);
            };
        }

        //public PackageModule(IBus bus, IRepository<Package> packages)
        //{
        //    Get["/Packages"] = _ =>
        //    {
        //        dto = Mapper.Map<IEnumerable<Package>, IEnumerable<PackageDto>>(packages);
        //        return Negotiate
        //            .WithView("Index")
        //            .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = dto });
        //    };

        //    Get["/Packages/Add"] = parameters =>
        //    {
        //        return View["Save", new PackageDto()];
        //    };

        //    Post["/Packages"] = _ =>
        //    {
        //        var dto = this.Bind<PackageDto>();
        //        var entity = Mapper.Map(dto, packages.Get(dto.Id) ?? new Package());

        //        bus.Publish(new CreateUpdateEntity(entity));

        //        return Response.AsJson("Test");
        //        return Negotiate
        //            .WithView("Index")
        //            .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = packages });
        //    };

        //    Get["/Packages/{id}"] = parameters =>
        //    {
        //        var guid = (Guid)parameters.id;
        //        var entity = packages.Get(guid);
        //        var dto = Mapper.Map<Package, PackageDto>(entity);
        //        return View["Save", dto];
        //    };

        //    Post["/Packages/{id}"] = _ =>
        //    {
        //        var dto = this.Bind<PackageDto>();
        //        var entity = Mapper.Map(dto, packages.Get(dto.Id) ?? new Package());

        //        bus.Publish(new CreateUpdateEntity(entity));

        //        return Negotiate
        //            .WithView("Index")
        //            .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = packages });
        //    };
        //}
    }
}