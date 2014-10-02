using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Models.Ivid.Dto;
using Nancy;
using Nancy.ModelBinding;
using NEventStore.Persistence.RavenDB;
using NHibernate.Id;
using NHibernate;
using PackageBuilder.Core.Helpers.MessageHandling;
using PackageBuilder.Core.Helpers.Cqrs.NEventStore;
using PackageBuilder.Core.Helpers.RavenDb.Indexes;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Client;
using Raven.Client.Linq;
using IHandleMessages = PackageBuilder.Core.Helpers.MessageHandling.IHandleMessages;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {

        

        public DataProviderModule(IHandleMessages handler, IRepository<DataProvider> repository, IDocumentSession session)
        {
            Get["/DataProvider"] = parameters =>
            {


                var res = session.Query<RavenCommit, TestingIndex>();
                                        

                //return Response.AsJson(new { res });
                return null;
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                Guid ProviderId = Guid.NewGuid();

                handler.Handle(new CreateDataProvider(ProviderId , 2, "Ivid", typeof(IvidResponse)));
                //handler.Handle(new UpdateReadModel(ProviderId,"Ivid", 1));

                return Response.AsJson(new { msg = "Success, "+ProviderId+" created" });
            };

            Get["/DataProvider/Edit/{id}"] = parameters =>
            {
                handler.Handle(new RenameDataProvider(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Get/{id}"] = parameters =>
            {
                var dataProviders = repository.GetById(parameters.id);
                return Response.AsJson(new { Response = dataProviders });
            };


            Post["/Dataprovider/Edit/{id}"] = parameters =>
            {

                //Guid ProviderId = Guid.NewGuid();
                DataProviderDto dto = this.Bind<DataProviderDto>();
                dto.incVersion();

                //TODO: Add Date for revised DataProvider
                handler.Handle(new CreateDataProviderRevision(parameters.id, dto.Version, dto.Name, typeof(DataProviderDto), dto.DataFields));


                return Response.AsJson(new { msg = "Success, " + parameters.id + " created" }); ;
            };

        }

    }
    

    //Mock-up for DataProvider Model-Bind
    public class DataProviderDto
    {

        public string Name { get; set; }

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