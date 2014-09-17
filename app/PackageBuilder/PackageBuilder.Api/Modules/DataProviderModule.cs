using System;
using Nancy;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(IHandleCommand handler)
        {
            Get["/DataProvider/Add"] = parameters =>
            {
                handler.Handle(new CreateDataProviderCommand(Guid.NewGuid(), "Test"));

                return Response.AsJson(new { msg = "Success" });
            };

            Get["/DataProvider/Edit/{id}"] = parameters =>
            {
                handler.Handle(new RenameDataProviderCommand(new Guid(parameters.id), "Test1"));

                return Response.AsJson(new { msg = "Success" });
            };
        }
    }
}