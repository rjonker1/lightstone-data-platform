﻿using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
{
    public class DataProviderMonitoringService : ICallMonitoringService
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly IHandleMonitoringCommands _handler;

        public DataProviderMonitoringService(IHandleMonitoringCommands handler)
        {
            _handler = handler;
        }

        public IEnumerable<MonitoringResponse> GetMonitoringInformationBySource(int source)
        {
            _log.InfoFormat("Getting Data Provider Monitoring View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto(source)));
            SetSearchMetaData(_handler.MonitoringResponse);
            return _handler.MonitoringResponse;
        }

        public IEnumerable<MonitoringResponse> GetMonitoringSummaryBySource(int source)
        {
            _log.InfoFormat("Getting Data Provider Monitoring Summary View");
            _handler.Handle(
                new GetMonitoringCommand(new MonitoringRequestDto(source)));
            SetSearchMetaData(_handler.MonitoringResponse);
            RemovePayload(_handler.MonitoringResponse);
            return _handler.MonitoringResponse;
        }

        public MonitoringResponse GetMonitoringResponseItem(System.Guid id, int source)
        {
            _log.InfoFormat("Getting Data Provider Monitoring Item");
            _handler.Handle(
                new GetMonitoringItemCommand(new MonitoringRequestDto(source, id)));
            SetSearchMetaData(new List<MonitoringResponse>()
            {
                {
                    _handler.MonitoringResponseItem
                }
            });
            return _handler.MonitoringResponseItem;
        }

        private static void RemovePayload(IEnumerable<MonitoringResponse> responses)
        {
            foreach (var response in responses)
            {
                response.RemovePayload();
            }
        }

        private static void SetSearchMetaData(IEnumerable<MonitoringResponse> responses)
        {
            foreach (var response in responses)
            {
                var requestInformation = response.Payload.JsonToObject<PackageInformation[]>();
                if (requestInformation == null || !requestInformation.Any())
                {
                    response.SetMetadata(string.Format("Aggregate {0} Date {1}", response.Id, response.Date));
                    continue;
                }

                var requestDetail =
                    requestInformation.FirstOrDefault(
                        f =>
                            f.EntryPointReceivedRequest != null && f.EntryPointReceivedRequest.Payload != null &&
                            f.EntryPointReceivedRequest.Payload.Request != null &&
                            f.EntryPointReceivedRequest.Payload.Request.Package != null);

                if (requestDetail == null)
                {
                    response.SetMetadata(string.Format("Aggregate {0} Date {1}", response.Id, response.Date));
                    continue;
                }

                response.SetMetadata(string.Format("{0} using {1}. Aggregate {2} Date {3}",
                    requestDetail.EntryPointReceivedRequest.Payload.Request.Package.Name,
                    requestDetail.EntryPointReceivedRequest.Payload.Request.SearchTerm, response.Id,
                    response.Date));
            }
        }
    }
}