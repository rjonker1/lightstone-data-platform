using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly ILog _log;
        private readonly IBus _bus;
        private ISendMonitoringCommandsToBus _monitoring;
        private IBuildSourceChain _sourceChain;
        private IBootstrap _bootstrap;
        private DataProviderStopWatch _stopWatch;

        public EntryPointService(IBus bus)
        {
            _log = LogManager.GetLogger(GetType());
            _bus = bus;
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            _log.DebugFormat("Receiving request into entry point. Request {0}",request);
            try
            {
                _monitoring = new SendEntryPointCommands(_bus, request.RequestAggregation.AggregateId,
                    (int) ExecutionOrder.First);

                _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
                _monitoring.Begin(request, _stopWatch);

                _sourceChain = new CreateSourceChain(request.Package);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    _log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    _monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            ChainBuilderError =
                                string.Format("Source chain could not be built for action {0}",
                                    request.Package.Action.Name)
                        });
                    _monitoring.End(request, _stopWatch);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request))
                {
                    _monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            DuplicateRequest = "This Request is duplicated and will not be executed"
                        });
                    _monitoring.End(request, _stopWatch);
                    return EmptyResponse;
                }

                _bootstrap = new Initialize(new LaceResponse(), request, _bus, _sourceChain);
                _bootstrap.Execute();

                _monitoring.End(_bootstrap.LaceResponses ?? EmptyResponse, _stopWatch);

                return _bootstrap.LaceResponses ?? EmptyResponse;

            }
            catch (Exception ex)
            {
                _monitoring.Send(CommandType.Fault, ex.Message, request);
                _monitoring.End(request, _stopWatch ?? new DataProviderStopWatch(DataProviderCommandSource.EntryPoint.ToString()));
                _log.ErrorFormat("Error occurred receiving request {0}",
                    request.ObjectToJson());
                return EmptyResponse;
            }
        }

        private static IList<LaceExternalSourceResponse> EmptyResponse
        {
            get
            {
                return new List<LaceExternalSourceResponse>()
                {
                    new LaceExternalSourceResponse()
                    {
                        Response = new LaceResponse()
                        {

                        }
                    }
                };
            }
        }
    }
}
