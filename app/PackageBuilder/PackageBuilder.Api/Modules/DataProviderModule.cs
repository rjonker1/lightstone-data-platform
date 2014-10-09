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
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Infrastructure.RavenDB.Indexes;
using Raven.Client;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IBus bus, INEventStoreRepository<DataProvider> repository, IDocumentSession session)
        {
            Get["/DataProvider"] = parameters =>
            {
                var res = session.Query<ReadDataProvider, IndexAllDataProviders>().ToList();
                                        
                return Response.AsJson(new { Response = res });   
            };

            Get["/DataProvider/DataSources"] = parameters =>
            {

                ArrayList DataSources = new ArrayList();

                var dataProviders = session.Query<ReadDataProvider, IndexAllDataProviders>()
                    .ToList();

                foreach (var provider in dataProviders)
                {

                    DataProviderDto dSource = new DataProviderDto();

                    dSource.Id = provider.DataProviderId;
                    dSource.Name = provider.Name;
                    dSource.Owner = provider.Owner;
                    dSource.Created = provider.Created;
                    dSource.Edited = provider.Edited;
                    dSource.Version = provider.Version;

                    try
                    {
                        dSource.DataFields = repository.GetById(provider.DataProviderId, provider.Version).DataFields
                                              .Select(field => new DataProviderFieldItemDto { Name = field.Name, Type = field.Type + "" });
                    }
                    catch (Exception)
                    {

                        dSource.DataFields = null;
                    }               

                    DataSources.Add(dSource);
                }

                return Response.AsJson(new { Response = DataSources });
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                Guid ProviderId = Guid.NewGuid();

                bus.Publish(new CreateDataProvider(ProviderId, "Ivid", typeof(IvidResponse)));

                return Response.AsJson(new { msg = "Success, "+ProviderId+" created" });
            };

            Get["/DataProvider/Edit/{id}/{version}"] = parameters =>
            {

                bus.Publish(new RenameDataProvider(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Get/{id}/{version}"] = parameters =>
            {

                var dataProviders = repository.GetById(parameters.id, parameters.version);
                return Response.AsJson(new { Response = dataProviders });
            };

            Post["/Dataprovider/Edit/{id}"] = parameters =>
            {
                DataProviderDto dto = this.Bind<DataProviderDto>();
                dto.incVersion();

                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(dto.DataFields);

                bus.Publish(new UpdateDataProvider(parameters.id, dto.Name, dto.Owner, dto.Created, dto.Edited, dto.Version, typeof(DataProviderDto),   dFields ));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " created" }); ;
            };
        }
    }
   
    //Mock-up for DataProvider Model-Bind
}