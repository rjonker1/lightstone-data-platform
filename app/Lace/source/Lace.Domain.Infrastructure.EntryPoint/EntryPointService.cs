using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
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
        private ILogCommandTypes _logCommand;
        public EntryPointService(IAdvancedBus bus)
        {
            _log = LogManager.GetLogger(GetType());
            _bus = bus;
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ICollection<IPointToLaceRequest> request)
        {
            try
            {
                if (request.First().Request.RequestId == Guid.Empty)
                {
                    _log.ErrorFormat("Request Id for Aggregation is required. Cannot complete request");
                    return EmptyResponse;
                }

                Init(request.First().Request.RequestId);

               _logCommand.LogBegin(request);

                if (ChainIsNotAvailable(request) || RequestIsDuplicated(request))
                    return EmptyResponse;

                _logCommand.LogEntryPointRequest(request);

                _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _dataProviderChain);
                _bootstrap.Execute();

                LogResponse(request);

                CreateTransaction(request, DataProviderState.Successful);

                _logCommand.LogEnd(_bootstrap.DataProviderResponses ?? EmptyResponse);

                return _bootstrap.DataProviderResponses ?? EmptyResponse;
            }
            catch (Exception ex)
            {
                _logCommand.LogFault(ex.Message, request);
                _logCommand.LogEnd(request);
                _log.ErrorFormat("Error occurred receiving request {0}",ex,request.ObjectToJson());
                LogResponse(request);
                CreateTransaction(request, DataProviderState.Failed);
                return EmptyResponse;
            }
        }

        private void Init(Guid requestId)
        {
            _command = CommandSender.InitCommandSender(_bus, requestId, DataProviderCommandSource.EntryPoint);
            _logCommand = LogCommandTypes.ForEntryPoint(_command);
            _workflow  = new SendWorkflowCommands(_bus,requestId);
        }

        private void LogResponse(ICollection<IPointToLaceRequest> request)
        {
            _logCommand.LogEntryPointResponse(_bootstrap.DataProviderResponses ?? EmptyResponse,
                _bootstrap.DataProviderResponses == null || _bootstrap.DataProviderResponses.Count == 0
                    ? DataProviderState.Failed
                    : DataProviderState.Successful, request);
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

        private bool ChainIsNotAvailable(IEnumerable<IPointToLaceRequest> request)
        {
            //_dataProviderChain = new CreateSourceChain(request.First().Package);
            //_dataProviderChain.Build();

            _dataProviderChain = new CreateSourceChain();

            if (_dataProviderChain.SourceChain != null)
                return false;

            _logCommand.LogFault(request, new {ChainBuilderError = "Source chain could not be built"});
            _logCommand.LogEnd(request);
            return true;
        }

        private bool RequestIsDuplicated(IEnumerable<IPointToLaceRequest> request)
        {
            if (!_checkForDuplicateRequests.IsRequestDuplicated(request.First()))
                return false;

            _logCommand.LogFault(request, new {DuplicateRequest = "This Request is duplicated and will not be executed"});
            _logCommand.LogEnd(request);
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
