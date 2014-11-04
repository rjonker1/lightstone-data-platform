using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Models.Ivid.Dto;
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
            INEventStoreRepository<Domain.Entities.DataProviders.WriteModels.DataProvider> writeRepo, IRepository<State> stateRepo)
        {
            Get["/DataProvider"] = parameters => { return Response.AsJson(readRepo); };

            Get["/DataProvider/Get/All"] = parameters =>
            {
                var dataSources = new ArrayList();

                foreach (var provider in readRepo)
                {
                    DataProviderDto dSource = new DataProviderDto();

                    dSource.Id = provider.DataProviderId;
                    dSource.Name = provider.Name;
                    dSource.CostOfSale = provider.CostPrice;
                    dSource.Description = provider.Description;
                    dSource.Owner = provider.Owner;
                    dSource.Created = provider.CreatedDate;
                    dSource.Edited = provider.EditedDate;
                    dSource.Version = provider.Version.Value;

                    try
                    {
                     
                        dSource.DataFields = writeRepo.GetById(provider.DataProviderId, provider.Version.Value).DataFields
                           .Select(field => new DataProviderFieldItemDto {Name = field.Name, Type = field.Type + ""});
                    }
                    catch (Exception ex)
                    {
                        dSource.DataFields = null;
                    }

                    dataSources.Add(dSource);
                }

                return Response.AsJson(dataSources);
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                var providerId = Guid.NewGuid();
                bus.Publish(new CreateDataProvider(providerId, "Ivid", "Ivid Datasource", 10d, "http://test", typeof(IvidResponse), stateRepo.FirstOrDefault(), "Al", DateTime.Now));

                return Response.AsJson(new { msg = "Success, "+providerId+" created" });
            };

            Get["/DataProvider/Get/{id}/{version}"] = parameters =>
            {
                var dpList = new ArrayList();

                DataProvider dataProvider;

                try
                {
                    dataProvider = writeRepo.GetById(parameters.id, parameters.version);
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
                bus.Publish(new UpdateDataProvider(parameters.id, dto.Name, dto.Description, dto.CostOfSale,
                    "http://test.com", typeof (DataProviderDto), stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.Created, dFields));

                return Response.AsJson(new {msg = "Success, " + parameters.id + " created"});
            };
        }
    }

}