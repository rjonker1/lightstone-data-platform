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
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public sealed class EntryPointService : IEntryPoint
    {
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
        }

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ICollection<IPointToLaceRequest> request)
        {
            try
            {
                Init(request.First().Request.RequestId);

                _logCommand.LogBegin(request);

                _dataProviderChain = new CreateSourceChain();
                _logCommand.LogEntryPointRequest(request,DataProviderNoRecordState.Billable);

                _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _dataProviderChain);
                _bootstrap.Execute();

                LogResponse(request);

                CreateTransaction(request, _bootstrap.DataProviderResponses.State());

                _logCommand.LogEnd(_bootstrap.DataProviderResponses ?? EmptyResponse);

                return _bootstrap.DataProviderResponses ?? EmptyResponse;
            }
            catch (Exception ex)
            {
                _logCommand.LogFault(ex.Message, request);
                _logCommand.LogEnd(request);
                _log.ErrorFormat("Error occurred receiving request {0}", ex, request.ObjectToJson());
                LogResponse(request);
                CreateTransaction(request, DataProviderResponseState.TechnicalError);
                return EmptyResponse;
            }
        }

        private void Init(Guid requestId)
        {
            _command = CommandSender.InitCommandSender(_bus, requestId, DataProviderCommandSource.EntryPoint);
            _logCommand = LogCommandTypes.ForEntryPoint(_command, DataProviderNoRecordState.Billable);
            _workflow  = new SendWorkflowCommands(_bus,requestId);
        }

        private void LogResponse(ICollection<IPointToLaceRequest> request)
        {
            _logCommand.LogEntryPointResponse(_bootstrap.DataProviderResponses ?? EmptyResponse,
                _bootstrap.DataProviderResponses == null || _bootstrap.DataProviderResponses.Count == 0
                    ? DataProviderResponseState.Failed
                    : DataProviderResponseState.Successful, request, DataProviderNoRecordState.Billable);
        }

        private void CreateTransaction(ICollection<IPointToLaceRequest> request, DataProviderResponseState state)
        {
            _workflow.CreateTransaction(request.GetFromRequest<IPointToLaceRequest>().Package.Id,
                request.GetFromRequest<IPointToLaceRequest>().Package.Version,
                request.GetFromRequest<IPointToLaceRequest>().User.UserId,
                request.GetFromRequest<IPointToLaceRequest>().Request.RequestId,
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractId,
                request.GetFromRequest<IPointToLaceRequest>().Request.System.ToString(),
                request.GetFromRequest<IPointToLaceRequest>().Contract.ContractVersion, state,
                request.GetFromRequest<IPointToLaceRequest>().Contract.AccountNumber,
                request.GetFromRequest<IPointToLaceRequest>().Package.PackageCostPrice,
                request.GetFromRequest<IPointToLaceRequest>().Package.PackageRecommendedPrice, DataProviderNoRecordState.Billable);
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
