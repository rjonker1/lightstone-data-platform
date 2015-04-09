using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PDto
    {
        public Guid UserId { get; set; }
    }
    public class PackageModule : SecureModule
    {
        public PackageModule(IPackageBuilderApiClient packageBuilderApi, IRepository<User> users)
        {
            Get["/Packages/{filter}"] = parameters =>
            {
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var packagesJson = packageBuilderApi.Get("", "Packages", new { parameters.filter }, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                var packages = JsonConvert.DeserializeObject<IEnumerable<PackageDto>>(packagesJson);
                //var dto = Mapper.Map<IEnumerable<PackageBuilder.Domain.Entities.Packages.ReadModels.Package>, IEnumerable<PackageDto>>(packages);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), packages);
            };

            Post["/Packages/GetPackage"] = parameters =>
            {
                var dto = this.Bind<PDto>();
                var user = users.Get(dto.UserId);
                var contractDto = Mapper.Map<Contract, ContractDto>(user.Contracts.First());

                if(!contractDto.Packages.Any())
                    throw new Exception("No packages for contract");

                return Response.AsJson(new { PackageId = contractDto.Packages.First().Key });
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