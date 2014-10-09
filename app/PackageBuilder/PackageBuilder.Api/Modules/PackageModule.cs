using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.Commands;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus)
        {
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

            Post[""] = parameters =>
            {
                return null;
            };

        }
    }

    public class PackageDto
    {
        public string Name { get; set; }
        public IEnumerable<DataProviderDto> DataProviderDtos { get; set; }
    }
}