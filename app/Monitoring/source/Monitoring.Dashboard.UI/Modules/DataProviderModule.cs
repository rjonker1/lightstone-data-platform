﻿using System.Linq;
using System.Text;
using DataPlatform.Shared.Enums;
using DataProvider.Domain.Extensions;
using DataProvider.Infrastructure.Base.Handlers;
using DataProvider.Infrastructure.Commands;
using DataProvider.Infrastructure.Dto.DataProvider;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        const int PageSize = 20;
        public DataProviderModule(IHandleMonitoringCommands handler)
        {
            this.RequiresAnyClaim(new[] {RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString()});

            Get["/dataProviders/log"] = _ => View["DataProvidersLog"];

            Get["/dataProviders/log/errors"] = _ => View["DataProvidersErrorLog"];

            Get["/dataProviders/indicators"] = _ => View["DataProvidersIndicators"];

            Get["/dataProviders/Query"] = _ => View["DataProvidersQuery"];

            Post["/dataProviders/log/search/{argument}/page/{page}"] = _ =>
            {
                var argument = _.argument;
                short page = _.page ?? 0;

                if (string.IsNullOrEmpty(argument))
                    return HttpStatusCode.BadRequest;

                handler.Handle(new GetMonitoringForArumentCommand(new MonitoringWithArgumentDto(argument, page, PageSize)));

                if (handler.MonitoringResponse == null || !handler.MonitoringResponse.Any())
                    return HttpStatusCode.NotFound;

                var model = new DataProviderWithPagesDto(handler.MonitoringResponse.OrderByDescending(o => o.Date).ToList());
                model.SetPages(model.Response[0].RowCount, PageSize);
                var bytes = Encoding.UTF8.GetBytes(model.AsJsonString());
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(bytes, 0, bytes.Length)
                };
            };
        }
    }
}