using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using FluentNHibernate.Testing.Values;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.Infrastructure.RavenDB.Indexes;
using Raven.Client;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IDocumentSession session)
        {
            Get["/Packages"] = parameters =>
            {
                var res = session.Query<ReadPackage, IndexAllPackages>().ToList();

                return Response.AsJson(new {Response = res});
            };

            Get["/Package/Add"] = parameters =>
            {
                var dto = new PackageDto
                {
                    Name = "VVi",
                    DataProviders = new List<DataProviderDto>
                    {
                        new DataProviderDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Ivid",
                            DataFields = new List<DataProviderFieldItemDto> {new DataProviderFieldItemDto {Name = "Colour"}}
                        }
                    }
                };

                var dp = Mapper.Map<DataProviderDto, DataProvider>(dto.DataProviders.First());

                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, new []{dp}));

                return Response.AsJson(new { msg = "Success" });
            };

            Post["/Package/Add"] = parameters =>
            {

                PackageDto dto = this.Bind<PackageDto>();

                var dProviders = Mapper.Map<DataProviderDto, DataProvider>(dto.DataProviders.First());

                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, new[]{dProviders} ));

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