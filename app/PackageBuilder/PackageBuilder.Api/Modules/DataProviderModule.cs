using System;
using Lace.Models.Ivid.Dto;
using Nancy;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IHandleMessages handler)
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
        }
    }
}