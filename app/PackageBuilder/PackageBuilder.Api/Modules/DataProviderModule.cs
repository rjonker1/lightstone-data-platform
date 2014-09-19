using System;
using Lace.Models.Ivid.Dto;
using Nancy;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.DataProviders.WriteModels;
using PackageBuilder.Domain.Helpers.Cqrs.NEventStore;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IHandleMessages handler, IRepository<DataProvider> repository)
        {
            Get["/DataProvider/Add"] = parameters =>
            {
                handler.Handle(new CreateDataProvider(Guid.NewGuid(), "Test3", typeof(IvidResponse)));

                return Response.AsJson(new { msg = "Success" });
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
        }
    }
}