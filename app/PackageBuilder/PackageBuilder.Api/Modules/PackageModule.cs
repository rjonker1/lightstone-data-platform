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
                return Response.AsJson(repository);
            };

            Get["/Package/Add"] = parameters =>
            {
                var dateTime = DateTime.Now;
                bus.Publish(new CreatePackage(Guid.NewGuid(), "Name", "Description", 10d, 20d, "Draft", "Owner", dateTime, dateTime, null));

                return Response.AsJson(new { msg = "Success" });
            };

            Post["/Package/Add"] = parameters =>
            {
                PackageDto dto = this.Bind<PackageDto>();

                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);

                var createdDate = DateTime.Now;
                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, "Description", dto.CostOfSale, 20d, dto.State, dto.Owner, createdDate, createdDate, dProviders));

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