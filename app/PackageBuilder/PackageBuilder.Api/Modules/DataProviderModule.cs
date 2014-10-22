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

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IBus bus, 
            IRepository<Domain.Entities.DataProviders.ReadModels.DataProvider> readRepo, 
            INEventStoreRepository<Domain.Entities.DataProviders.WriteModels.DataProvider> writeRepo)
        {
            Get["/DataProvider"] = parameters =>
            {
                return Response.AsJson(readRepo);
            };

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
                    dSource.Version = provider.Version;

                    try
                    {
                        dSource.DataFields = writeRepo.GetById(provider.DataProviderId, provider.Version).DataFields
                                              .Select(field => new DataProviderFieldItemDto { Name = field.Name, Type = field.Type + "" });
                    }
                    catch (Exception)
                    {
                        dSource.DataFields = null;
                    }

                    dataSources.Add(dSource);
                }

                return Response.AsJson(new { Response = dataSources });
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                var providerId = Guid.NewGuid();
                bus.Publish(new CreateDataProvider(providerId, "Ivid", "Ivid Datasource", 10d, "hhtp://test", typeof(IvidResponse), "draft", "Al", DateTime.Now));

                return Response.AsJson(new { msg = "Success, "+providerId+" created" });
            };

            Get["/DataProvider/Edit/{id}/{version}"] = parameters =>
            {
                bus.Publish(new RenameDataProvider(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Get/{id}/{version}"] = parameters =>
            {
                var dataProviders = writeRepo.GetById(parameters.id, parameters.version);
                return Response.AsJson(new { Response = dataProviders });
            };

            Post["/Dataprovider/Edit/{id}"] = parameters =>
            {
                var dto = this.Bind<DataProviderDto>();
                //DataFieldMap
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(dto.DataFields);
                bus.Publish(new UpdateDataProvider(parameters.id, dto.Name, dto.Description, dto.CostOfSale, "http://test.com", typeof(DataProviderDto), "Draft", dto.Owner, dto.Created, dFields));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " created" }); ;
            };
        }
    }
}