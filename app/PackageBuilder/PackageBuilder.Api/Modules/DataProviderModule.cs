using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IBus bus,
            IDataProviderRepository readRepo,
            INEventStoreRepository<DataProvider> writeRepo, IRepository<State> stateRepo)
        {
            Get["/DataProvider"] = parameters => { return Response.AsJson(readRepo); };

            Get["/DataProvider/Get/All"] = parameters =>
            {
                var dataSources = new ArrayList();

                foreach (var provider in readRepo)
                {

                    DataProviderDto dSource = null;

                    try
                    {
                        dSource = Mapper.Map<IDataProvider, DataProviderDto>(writeRepo.GetById(provider.DataProviderId, provider.Version.Value));
                    }
                    catch (Exception ex)
                    {
                        //dSource.DataFields = null;
                    }

                    dataSources.Add(dSource);
                }

                return Response.AsJson(dataSources);
            };

            Get["/DataProvider/Get/{id}/{version}"] = parameters =>
            {
                var dpList = new ArrayList();

                DataProviderDto dataProvider;

                try
                {
                    var dp = writeRepo.GetById(parameters.id, parameters.version);
                    dataProvider = Mapper.Map<IDataProvider, DataProviderDto>(dp);
                }
                catch (Exception)
                {
                    dataProvider = null;
                }

                dpList.Add(dataProvider);

                return Response.AsJson(new { Response = dpList });
            };

            Post["/Dataprovider/Edit/{id}"] = parameters =>
            {
                var dto = this.Bind<DataProviderDto>();
                //DataFieldMap
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(dto.DataFields);
                bus.Publish(new UpdateDataProvider(parameters.id, (DataProviderName)Enum.Parse(typeof(DataProviderName), dto.Name, true), dto.Description, dto.CostOfSale,
                    "http://test.com", typeof (DataProviderDto), dto.FieldLevelCostPriceOverride, stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.Created, dFields));

                return Response.AsJson(new {msg = "Success, " + parameters.id + " created"});
            };
        }
    }

}