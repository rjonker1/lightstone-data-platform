using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using NServiceBus;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly ILog _log;
        private readonly IBus _bus;
        private ISendCommandToBus _command;
        private ISendWorkflowCommand _workflow;
        private IBuildSourceChain _sourceChain;
        private IBootstrap _bootstrap;
        private DataProviderStopWatch _stopWatch;

        public EntryPointService(IBus bus)
        {
            _log = LogManager.GetLogger(GetType());
            _bus = bus;
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ICollection<IPointToLaceRequest> request)
        {
            _log.DebugFormat("Receiving request into entry point. Request {0}", request);
            try
            {
                if (request.First().Request.RequestId == Guid.Empty)
                    throw new Exception("Request Id for Aggregation is required. Cannot complete request");

                _command = CommandSender.InitCommandSender(_bus, request.First().Request.RequestId,
                    (int) ExecutionOrder.First, DataProviderCommandSource.EntryPoint);

                _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
                _command.Monitoring.Begin(request, _stopWatch);

                _sourceChain = new CreateSourceChain(request.First().Package);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    _log.ErrorFormat("Source chain could not be built for action {0}", request.First().Package.Action);
                    _command.Monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            ChainBuilderError =
                                string.Format("Source chain could not be built for action {0}",
                                    request.First().Package.Action)
                        });
                    _command.Monitoring.End(request, _stopWatch);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request.First()))
                {
                    _command.Monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            DuplicateRequest = "This Request is duplicated and will not be executed"
                        });
                    _command.Monitoring.End(request, _stopWatch);
                    return EmptyResponse;
                }

                _workflow = new SendWorkflowCommands(_bus, request.First().Request.RequestId);
                _workflow.DataProviderRequestTransaction(DataProviderCommandSource.EntryPoint, string.Empty,
                    string.Empty,
                    DateTime.Now, DataProviderAction.Request, DataProviderState.Successful);

                _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _sourceChain);
                _bootstrap.Execute();

                _workflow.DataProviderResponseTransaction(DataProviderCommandSource.EntryPoint, string.Empty,
                    string.Empty,
                    DateTime.Now, DataProviderAction.Response,
                    _bootstrap.DataProviderResponses == null || _bootstrap.DataProviderResponses.Count == 0
                        ? DataProviderState.Failed
                        : DataProviderState.Successful);
                _command.Monitoring.End(_bootstrap.DataProviderResponses ?? EmptyResponse, _stopWatch);


                return _bootstrap.DataProviderResponses ?? EmptyResponse;

            }
            catch (Exception ex)
            {
                _command.Monitoring.Send(CommandType.Fault, ex.Message, request);
                _command.Monitoring.End(request,
                    _stopWatch ?? new DataProviderStopWatch(DataProviderCommandSource.EntryPoint.ToString()));
                _log.ErrorFormat("Error occurred receiving request {0}",
                    request.ObjectToJson());
                return EmptyResponse;
            }
        }

        private static ICollection<IPointToLaceProvider> EmptyResponse
        {
            get
            {
                return new List<IPointToLaceProvider>();
            }
        }
    }
}
