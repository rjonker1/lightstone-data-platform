using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Workflow.Lace.Domain;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private readonly ILog _log;
        private readonly IAdvancedBus _bus;
        private ISendCommandToBus _command;
        private ISendWorkflowCommand _workflow;
        private IBuildSourceChain _dataProviderChain;
        private IBootstrap _bootstrap;
        private DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.EntryPoint;

        public EntryPointService(IAdvancedBus bus)
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

                Init(request.First().Request.RequestId);
                
                _command.Workflow.Begin(request, _stopWatch, Provider);

                if (ChainIsNotAvailable(request) || RequestIsDuplicated(request))
                    return EmptyResponse;
                
                LogRequest(request);

                _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _dataProviderChain);
                _bootstrap.Execute();

                LogResponse(request);

                CreateTransaction(request, DataProviderState.Successful);

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
                LogResponse(request);
                CreateTransaction(request, DataProviderState.Failed);
                return EmptyResponse;
            }
        }

        private void Init(Guid requestId)
        {
            _command = CommandSender.InitCommandSender(_bus, requestId, Provider);
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.EntryPoint);
            _workflow = new SendWorkflowCommands(_bus, requestId);
        }

        private void LogRequest(ICollection<IPointToLaceRequest> request)
        {
            _workflow.EntryPointRequest(request, _stopWatch);
        }

        private void LogResponse(ICollection<IPointToLaceRequest> request)
        {
            _workflow.EntryPointResponse(_bootstrap.DataProviderResponses ?? EmptyResponse, _stopWatch,
                _bootstrap.DataProviderResponses == null || _bootstrap.DataProviderResponses.Count == 0
                    ? DataProviderState.Failed
                    : DataProviderState.Successful,request);
        }

        private void CreateTransaction(ICollection<IPointToLaceRequest> request,DataProviderState state)
        {
            _workflow.CreateTransaction(request.GetFromRequest<IPointToLaceRequest>().Package.Id,
                request.GetFromRequest<IPointToLaceRequest>().Package.Version,
                request.GetFromRequest<IPointToLaceRequest>().User.UserId,
                request.GetFromRequest<IPointToLaceRequest>().Request.RequestId,
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractId,
                request.GetFromRequest<IPointToLaceRequest>().Request.System.ToString(),
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractVersion, state,
                request.GetFromRequest<IPointToLaceRequest>().Contract.AccountNumber);
        }

        private static void RequestHasId(bool requestIdIsEmpty)
        {
            if (requestIdIsEmpty)
                throw new Exception("Request Id for Aggregation is required. Cannot complete request");
        }

        private bool ChainIsNotAvailable(ICollection<IPointToLaceRequest> request)
        {
            _dataProviderChain = new CreateSourceChain(request.First().Package);
            _dataProviderChain.Build();

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
