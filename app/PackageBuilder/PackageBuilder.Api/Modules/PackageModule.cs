using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IRepository<PackageBuilder.Domain.Entities.Packages.ReadModels.Package> readRepo,
                                        INEventStoreRepository<PackageBuilder.Domain.Entities.Packages.WriteModels.Package> writeRepo, IRepository<State> stateRepo)
        {
            Get["/Packages"] = parameters =>
            {
                return Response.AsJson(readRepo);
            };

            Get["/Package/Add"] = parameters =>
            {
                var dateTime = DateTime.Now;
                bus.Publish(new CreatePackage(Guid.NewGuid(), "Name", "Description", 10d, 20d, stateRepo.FirstOrDefault(), "Owner", dateTime, dateTime, null));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/Package/Get/{id}/{version}"] = parameters =>
            {

                var pkgList = new ArrayList();

                Package package;

                try
                {
                    package = writeRepo.GetById(parameters.id, parameters.version);
                }
                catch (Exception ex)
                {
                    package = null;
                }

                pkgList.Add(package);

                return Response.AsJson(new { Response = pkgList });

                //var package = writeRepo.GetById(parameters.id, parameters.versyion);
                //return Response.AsJson(new { Response = package });
            };

            Post["/Package/Add"] = parameters =>
            {
                PackageDto dto = this.Bind<PackageDto>();

                var stateResolve = stateRepo.Where(x => x.Alias == dto.State).Select(y => new State(y.Id, y.Name, y.Alias));

                //DataProviderMap
                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);

                var createdDate = DateTime.Now;
                //bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, dto.Description, dto.CostOfSale, dto.RecommendedSalePrice, stateRepo.FirstOrDefault(), dto.Owner, createdDate, null, dProviders));
                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, dto.Description, dto.CostOfSale, dto.RecommendedSalePrice, stateResolve.FirstOrDefault(), dto.Owner, createdDate, null, dProviders));

                return Response.AsJson(new { msg = "Success" });
            };

            Post["/Package/Edit/{id}"] = parameters =>
            {
                PackageDto dto = this.Bind<PackageDto>();

                var stateResolve = stateRepo.Where(x => x.Alias == dto.State).Select(y => new State(y.Id, y.Name, y.Alias));

                //DataProviderMap
                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);

                var editedDate = DateTime.Now;
                bus.Publish(new UpdatePackage(parameters.id, dto.Name, dto.Description, dto.CostOfSale, dto.RecommendedSalePrice, stateResolve.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, editedDate, dProviders));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " edited" });
            };

        }
    }

    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int Version { get; set; }
        public string Industry { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Owner { get; set; }
        public double CostOfSale { get; set; }
        public double RecommendedSalePrice { get; set; }
        public IEnumerable<DataProviderDto> DataProviders { get; set; }
    }
}