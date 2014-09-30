using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Models.Ivid.Dto;
using Nancy;
using Nancy.ModelBinding;
<<<<<<< HEAD
using NHibernate.Id;
=======
using NHibernate;
>>>>>>> origin/MVP
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;
using PackageBuilder.Domain.Helpers.RavenDb.Indexes;
using Raven.Client;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {

        

        public DataProviderModule(IHandleMessages handler, IRepository<DataProvider> repository, IDocumentSession session)
        {
            Get["/DataProvider"] = parameters =>
            {
                var dataProviders = session.Query<IndexDataProviersByName>();

                return Response.AsJson(new { dataProviders });
            };

            Get["/DataProvider/Add"] = parameters =>
            {
                Guid ProviderId = Guid.NewGuid();

                handler.Handle(new CreateDataProvider(ProviderId , 1, "Ivid", typeof(IvidResponse)));

                return Response.AsJson(new { msg = "Success, "+ProviderId+" created" });
            };

            Get["/DataProvider/Edit/{id}"] = parameters =>
            {
                handler.Handle(new RenameDataProvider(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Get/{id}"] = parameters =>
            {
                var dataProviders = repository.GetById(parameters.id, 1);
                return Response.AsJson(new { Response = dataProviders });
            };


            Post["/Dataprovider/Add"] = parameters =>
            {

                Guid ProviderId = Guid.NewGuid();
                DataProviderDto dto = this.Bind<DataProviderDto>();
                dto.incVersion();

                handler.Handle(new CreateDataProviderRevision(ProviderId, dto.Version, dto.Name, typeof(DataProviderDto), dto.DataFields));


                return Response.AsJson(new { msg = "Success, " + ProviderId + " created" }); ;
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