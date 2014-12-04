using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.Packages.Commands;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Api.Modules
{
    public class PackageModule : NancyModule
    {
        public PackageModule(IBus bus, IRepository<Domain.Entities.Packages.ReadModels.Package> readRepo,
                                        INEventStoreRepository<Package> writeRepo, IRepository<State> stateRepo)
        {
            Get["/Packages"] = parameters =>
                 Response.AsJson(readRepo);

            Get["/Package/Get/{id}/{version}"] = parameters =>
                 Response.AsJson(new { Response = new[] { Mapper.Map<IPackage, PackageDto>(writeRepo.GetById(parameters.id)) } });

            Post["/Package/Add"] = parameters =>
            {
                var dto = this.Bind<PackageDto>();

                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);
                var stateResolve = stateRepo.Where(x => x.Alias == dto.State).Select(y => new State(y.Id, y.Name, y.Alias));
                bus.Publish(new CreatePackage(Guid.NewGuid(), dto.Name, dto.Description, dto.CostOfSale, dto.RecommendedSalePrice, dto.Notes, dto.Industries, stateResolve.FirstOrDefault(), dto.Owner, DateTime.Now, null, dProviders));

                return Response.AsJson(new { msg = "Success" });
            };

            Post["/Package/Edit/{id}"] = parameters =>
            {
                var dto = this.Bind<PackageDto>();
                var dProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<IDataProvider>>(dto.DataProviders);
                var stateResolve = stateRepo.Where(x => x.Alias == dto.State).Select(y => new State(y.Id, y.Name, y.Alias));

                bus.Publish(new UpdatePackage(parameters.id, dto.Name, dto.Description, dto.CostOfSale, dto.RecommendedSalePrice, dto.Notes, dto.Industries, stateResolve.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.Now, dProviders));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " edited" });
            };
        }
    }
}