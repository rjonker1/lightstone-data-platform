using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using NServiceBus;
using Workflow.Lace.Identifiers;
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
        private IBuildSourceChain _dataProviderChain;
        private IBootstrap _bootstrap;
        private DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.EntryPoint;

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
                RequestHasId(request.First().Request.RequestId == Guid.Empty);

                _command = CommandSender.InitCommandSender(_bus, request.First().Request.RequestId, Provider);

                _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
                _command.Workflow.Begin(request, _stopWatch, Provider);

                _dataProviderChain = new CreateSourceChain(request.First().Package);
                _dataProviderChain.Build();

                if (ChainIsNotAvailable(request) || RequestIsDuplicated(request))
                    return EmptyResponse;

                _workflow = new SendWorkflowCommands(_bus, request.First().Request.RequestId);
                LogRequest(request);

                _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _dataProviderChain);
                _bootstrap.Execute();

                 LogResponse(request);

                 CreateTransaction(request);

                _command.Workflow.End(_bootstrap.DataProviderResponses ?? EmptyResponse, _stopWatch, Provider);


                return _bootstrap.DataProviderResponses ?? EmptyResponse;

            }
            catch (Exception ex)
            {
                _command.Workflow.Send(CommandType.Fault, ex.Message, request, Provider);
                _command.Workflow.End(request,
                    _stopWatch ?? new DataProviderStopWatch(DataProviderCommandSource.EntryPoint.ToString()), Provider);
                _log.ErrorFormat("Error occurred receiving request {0}",
                    request.ObjectToJson());
                return EmptyResponse;
            }
        }

        private void LogRequest(ICollection<IPointToLaceRequest> request)
        {
            _workflow.DataProviderRequest(
                    new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Request,
                        DataProviderState.Successful),
                    new ConnectionTypeIdentifier(string.Empty, string.Empty), request,
                    _stopWatch);
        }

        private void LogResponse(ICollection<IPointToLaceRequest> request)
        {
            _workflow.DataProviderResponse(
                   new DataProviderIdentifier(DataProviderCommandSource.EntryPoint, DataProviderAction.Response,
                       _bootstrap.DataProviderResponses == null || _bootstrap.DataProviderResponses.Count == 0
                           ? DataProviderState.Failed
                           : DataProviderState.Successful),
                   new ConnectionTypeIdentifier(string.Empty, string.Empty),
                   _bootstrap.DataProviderResponses ?? EmptyResponse,
                   _stopWatch);
        }

        private void CreateTransaction(ICollection<IPointToLaceRequest> request)
        {
            _workflow.CreateTransaction(request.GetFromRequest<IPointToLaceRequest>().Package.Id,
                request.GetFromRequest<IPointToLaceRequest>().Package.Version,
                request.GetFromRequest<IPointToLaceRequest>().User.UserId,
                request.GetFromRequest<IPointToLaceRequest>().Request.RequestId,
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractId,
                request.GetFromRequest<IPointToLaceRequest>().Request.System.ToString(),
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractVersion, DataProviderState.Successful,
                request.GetFromRequest<IPointToLaceRequest>().Contract.AccountNumber);
        }

        private static void RequestHasId(bool requestIdIsEmpty)
        {
            if (requestIdIsEmpty)
                throw new Exception("Request Id for Aggregation is required. Cannot complete request");
        }

        private bool ChainIsNotAvailable(ICollection<IPointToLaceRequest> request)
        {
            if (_dataProviderChain.SourceChain != null)
                return false;

            _log.ErrorFormat("Source chain could not be built for action {0}", request.First().Package.Action);
            _command.Workflow.Send(CommandType.Fault, request,
                new
                {
                    ChainBuilderError =
                        string.Format("Source chain could not be built for action {0}",
                            request.First().Package.Action)
                }, Provider);
            _command.Workflow.End(request, _stopWatch, Provider);
            return true;
        }

        private bool RequestIsDuplicated(IEnumerable<IPointToLaceRequest> request)
        {
            if (!_checkForDuplicateRequests.IsRequestDuplicated(request.First()))
                return false;

            _command.Workflow.Send(CommandType.Fault, request,
                      new
                      {
                          DuplicateRequest = "This Request is duplicated and will not be executed"
                      }, Provider);
            _command.Workflow.End(request, _stopWatch, Provider);
            return true;
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
