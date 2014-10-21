using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Dto;
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
                    dSource.CostOfSale = provider.CostOfSale;
                    dSource.Description = provider.Description;
                    dSource.Owner = provider.Owner;
                    dSource.Created = provider.Created;
                    dSource.Edited = provider.Edited;
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
                Guid ProviderId = Guid.NewGuid();
                bus.Publish(new CreateDataProvider(ProviderId, "Ivid", "Ivid Datasource", typeof(IvidResponse)));
                //bus.Publish(new DataProviderCreated(Guid.NewGuid(), ProviderId, "Ivid", "Ivid Datasource", typeof(IvidResponse), null));
                //readRepo.Save(new DataProvider(Guid.NewGuid(), ProviderId, "Ivid", 0d, "Description", null));
                return Response.AsJson(new { msg = "Success, "+ProviderId+" created" });
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
                DataProviderDto dto = this.Bind<DataProviderDto>();
                dto.incVersion();

                //DataFieldMap
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(dto.DataFields);

                bus.Publish(new UpdateDataProvider(parameters.id, dto.Name, dto.Description, dto.Owner, dto.Created, dto.Edited, dto.Version, typeof(DataProviderDto),   dFields ));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " created" }); ;
            };
        }
    }
}