using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Models.Ivid.Dto;
using MemBus;
using Nancy;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using PackageBuilder.Domain.Models;
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

                var res = session.Query<ReadDataProvider, IndexAllDataProviders>()
                    .ToList();
                                        
                return Response.AsJson(new { Response = res });   
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                Guid ProviderId = Guid.NewGuid();

                bus.Publish(new CreateDataProvider(ProviderId, "Ivid", typeof(IvidResponse)));

                return Response.AsJson(new { msg = "Success, "+ProviderId+" created" });
            };

            Get["/DataProvider/Edit/{id}"] = parameters =>
            {

                bus.Publish(new RenameDataProvider(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Get/{id}"] = parameters =>
            {

                var dataProviders = repository.GetById(parameters.id);
                return Response.AsJson(new { Response = dataProviders });
            };

            Post["/Dataprovider/Edit/{id}"] = parameters =>
            {

                DataProviderDto dto = this.Bind<DataProviderDto>();
                dto.incVersion();

                Guid dataRecordId = Guid.NewGuid();

                bus.Publish(new UpdateDataProvider(dataRecordId, parameters.id, dto.Name, dto.Owner, dto.Created, dto.Edited, dto.Version, typeof(DataProviderDto), dto.DataFields));

                return Response.AsJson(new { msg = "Success, " + parameters.id + " created" }); ;
            };
        }
    }
    

    //Mock-up for DataProvider Model-Bind
    public class DataProviderDto
    {

        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public int Version { get; set; }

        public int incVersion()
        {
            return Version++;
        }

        public IEnumerable<DataProviderFieldItemDto> DataFields { get; set; }

    }

    public class DataProviderFieldItemDto
    {
      
        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Definition { get; set; }
        public string Industries { get; set; }
        public double Price { get; set; }
        public bool IsSelected { get; set; }

    }
}