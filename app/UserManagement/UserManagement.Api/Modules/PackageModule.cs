using System;
using System.Linq;
using AutoMapper;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using Shared.BuildingBlocks.Api.ApiClients;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class PDto
    {
        public Guid UserId { get; set; }
    }

    public class PackageModule : NancyModule //: SecureModule
    {
        public PackageModule(IPackageBuilderApiClient packageBuilderApi, IRepository<User> users)
        {
            Get["/Packages"] = parameters =>
            {
                var filter = Context.Request.Query["q_word[]"].Value.ToString();
                var pageIndex = 0;
                var pageSize = 0;
                int.TryParse(Context.Request.Query["page_num"].Value, out pageIndex);
                int.TryParse(Context.Request.Query["per_page"].Value, out pageSize);

                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var resource = string.Format("/Packages/{0}/{1}/{2}", filter, pageIndex - 1, pageSize).ToString();
                var packagesJson = packageBuilderApi.Get("", (string)resource);
               // var packages = packageBuilderApi.Get<Test>("", string.Format("/Packages/{0}/{1}/{2}", filter, pageIndex, pageSize), null, new[] { new KeyValuePair<string, string>("Authorization", "Token " + token) });
                var packages = JsonConvert.DeserializeObject<PagedCollectionDto<PackageDto>>(packagesJson);
                //var result = packages.Select(x => new { id = x.Id, name = x.Name });
                //var dto = Mapper.Map<IEnumerable<PackageBuilder.Domain.Entities.Packages.ReadModels.Package>, IEnumerable<PackageDto>>(packages);
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new {result = packages.Data, cnt_whole = packages.RecordsFiltered});
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