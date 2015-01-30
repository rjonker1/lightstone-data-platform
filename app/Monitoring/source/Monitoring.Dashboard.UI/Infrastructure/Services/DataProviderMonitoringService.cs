using System;
using System.Collections.Generic;
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
            CheckForErrors(_handler.MonitoringResponse);
            GetPerformanceResults(_handler.MonitoringResponse);
            return _handler.MonitoringResponse;
        }

        private static void CheckForErrors(IEnumerable<MonitoringResponse> responses)
        {
            foreach (var response in responses)
            {
                var errors = response.Payload.JsonToObject<Errors[]>();

                if (errors == null || !errors.Any())
                    continue;

                var errorsExist = errors.FirstOrDefault(w => w.ThrowError != null);

                if(errorsExist == null)
                    continue;

                response.ErrorsExist();
            }
        }

        private void GetPerformanceResults(IEnumerable<MonitoringResponse> responses)
        {
            try
            {


                foreach (var response in responses)
                {
                    var performance = response.Payload.JsonToObject<PerformanceMetaData[]>();
                    if (performance == null || !performance.Any())
                        continue;

                    var performanceExists =
                        performance.FirstOrDefault(
                            w =>
                                w.EntryPointProcessedAndReturningRequest != null &&
                                w.EntryPointProcessedAndReturningRequest.MetaData != null &&
                                w.EntryPointProcessedAndReturningRequest.MetaData.Results != null &&
                                w.EntryPointProcessedAndReturningRequest.MetaData.Results.Name == "EntryPoint");

                    if (performanceExists == null)
                        continue;

                    response.SetPerformanceData(string.Format("Elapsed Time: {0}",
                        performanceExists.EntryPointProcessedAndReturningRequest.MetaData.Results.ElapsedTime));
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Data Provider Monitoring Service error getting performance results: {0}", ex.Message);
            }
        }

        private static void SetSearchMetaData(IEnumerable<MonitoringResponse> responses)
        {
            foreach (var response in responses)
            {
                var requestInformation = response.Payload.JsonToObject<PackageInformation[]>();
                if (requestInformation == null || !requestInformation.Any())
                {
                    response.SetMetadata(string.Format("Id {0} Date {1}", response.Id, response.Date));
                    continue;
                }

                var requestDetail =
                    requestInformation.FirstOrDefault(
                        f =>
                            f.EntryPointReceivedRequest != null && f.EntryPointReceivedRequest.Payload != null &&
                            f.EntryPointReceivedRequest.Payload.Package != null);

                if (requestDetail == null)
                {
                    response.SetMetadata(string.Format("Id {0} Date {1}", response.Id, response.Date));
                    continue;
                }

                response.SetMetadata(string.Format("{0} using {1}. Date {2}",
                    requestDetail.EntryPointReceivedRequest.Payload.Package.Name,
                    requestDetail.EntryPointReceivedRequest.Payload.SearchTerm, response.Date));
            }
        }
    }
}