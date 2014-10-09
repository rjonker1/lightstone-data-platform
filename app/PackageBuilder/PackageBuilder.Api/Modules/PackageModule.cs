using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
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
            Get["/Package"] = parameters =>
            {
                var res = session.Query<ReadPackage, IndexAllPackages>().ToList();

                return Response.AsJson(new {Response = res});
            };

            Get["/Package/Add"] = parameters =>
            {
                var dto = new PackageDto
                {
                    Name = "VVi",
                    DataProviderDtos = new List<DataProviderDto>
                    {
                        new DataProviderDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Ivid",
                            DataFields = new List<DataProviderFieldItemDto> {new DataProviderFieldItemDto {Name = "Colour"}}
                        }
                    }
                };

                var dp = Mapper.Map<DataProviderDto, DataProvider>(dto.DataProviderDtos.First());

                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, new []{dp}));

                return Response.AsJson(new { msg = "Success" });
            };
        }
    }

    public class PackageDto
    {
        public string Name { get; set; }
        public IEnumerable<DataProviderDto> DataProviderDtos { get; set; }
    }
}