using System;
using System.Collections.Generic;
using AutoMapper;
using DataPlatform.Shared.Entities;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IRepository<Package> repository)
        {
            Get["/Packages"] = parameters =>
            {
                //var res = session.Query<ReadPackage, IndexAllPackages>().ToList();

                //return Response.AsJson(new {Response = res});

                return Response.AsJson(repository);
            };

            Get["/Package/Add"] = parameters =>
            {
                bus.Publish(new CreatePackage(Guid.NewGuid(), "Test", null));

                return Response.AsJson(new { msg = "Success" });
            };

            Post["/Package/Add"] = parameters =>
            {
                PackageDto dto = this.Bind<PackageDto>();

                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);

                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, dProviders ));

                return Response.AsJson(new { msg = "Success" });
            };
        }
    }

    public class PackageDto
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Industry { get; set; }
        public DateTime RevisionDate { get; set; }
        public string Owner { get; set; }
        public int CostOfSale { get; set; }
        public int RecommendedSalePrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }
}