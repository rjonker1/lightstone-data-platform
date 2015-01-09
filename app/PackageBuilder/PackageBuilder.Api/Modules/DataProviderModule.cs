using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using MemBus;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        private static int _defaultJsonMaxLength;

        public DataProviderModule(IBus bus,
            IDataProviderRepository readRepo,
            INEventStoreRepository<DataProvider> writeRepo, IRepository<State> stateRepo)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/DataProviders"] = parameters =>
                Response.AsJson(readRepo);

            Get["/DataProviders/Latest"] = parameters =>
            {
                var dataSources = readRepo.GetUniqueIds().Select(x => Mapper.Map<IDataProvider, DataProviderDto>(writeRepo.GetById(x))).ToList();
                return Response.AsJson(dataSources);
            };

            Get["/DataProviders/{id}"] = parameters => 
                Response.AsJson(new { Response = new []{ Mapper.Map<IDataProvider, DataProviderDto>(writeRepo.GetById(parameters.id)) } });

            Get["/DataProviders/{id}/{version}"] = parameters =>
                Response.AsJson(new { Response = new[] { Mapper.Map<IDataProvider, DataProviderDto>(writeRepo.GetById(parameters.id, parameters.version)) } });

            Put["/Dataproviders/{id}"] = parameters =>
            {
                var dto = this.Bind<DataProviderDto>();
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(dto.DataFields);
                bus.Publish(new UpdateDataProvider(parameters.id,
                    (DataProviderName) Enum.Parse(typeof (DataProviderName), dto.Name, true), dto.Description,
                    dto.CostOfSale, typeof (DataProviderDto), dto.FieldLevelCostPriceOverride,
                    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.Now, dFields));

                return Response.AsJson(new {msg = "Success, " + parameters.id + " created"});
            };
        }
    }
}