using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
    public sealed class EntryPointAsyncService : IEntryPointAsync
    {
        private static readonly ILog Log = LogManager.GetLogger<EntryPointService>();
        private readonly IAdvancedBus _bus;
        private ISendCommandToBus _command;
        private ISendWorkflowCommand _workflow;
        private readonly IBuildSourceChain _dataProviderChain;
        private IBootstrap _bootstrap;
        private ILogCommandTypes _logCommand;

        public EntryPointAsyncService(IAdvancedBus bus)
        {
            _bus = bus;
            _dataProviderChain = new SpecificationFactory();
        }

        public async Task<ICollection<IPointToLaceProvider>> GetResponsesForCarIdAsync(ICollection<IPointToLaceRequest> request)
        {
            return await Execute(request, ChainType.CarId);
        }

        public async Task<ICollection<IPointToLaceProvider>> GetResponsesAsync(ICollection<IPointToLaceRequest> request)
        {
            return await Execute(request, ChainType.All);
        }

        private async Task<ICollection<IPointToLaceProvider>> Execute(ICollection<IPointToLaceRequest> request, ChainType chain)
        {
            var response = await Task.Factory.StartNew(() =>
            {
                try
                {
                    Init(request.First().Request.RequestId);

                    _logCommand.LogBegin(request);
                    _logCommand.LogEntryPointRequest(request, DataProviderNoRecordState.Billable);

                    _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _dataProviderChain);
                    _bootstrap.Execute(chain);

                    LogResponse(request);

                    CreateTransaction(request, _bootstrap.DataProviderResponses.State());

                    _logCommand.LogEnd(_bootstrap.DataProviderResponses ?? EmptyResponse);
                    return _bootstrap.DataProviderResponses ?? EmptyResponse;
                }
                catch (Exception ex)
                {
                    _logCommand.LogFault(ex.Message, request);
                    _logCommand.LogEnd(request);
                    Log.ErrorFormat("Error occurred receiving request {0}", ex, request.ObjectToJson());
                    LogResponse(request);
                    CreateTransaction(request, DataProviderResponseState.TechnicalError);
                    return EmptyResponse;
                }
            });

            return response;
        }



        private async void Init(Guid requestId)
        {
            _command = CommandSender.InitCommandSender(_bus, requestId, DataProviderCommandSource.EntryPoint);
            _logCommand = LogCommandTypes.ForEntryPoint(_command, DataProviderNoRecordState.Billable);
            _workflow = new SendWorkflowCommands(_bus, requestId);
        }
    

    private async void LogResponse(ICollection<IPointToLaceRequest> request)
    {
        _logCommand.LogEntryPointResponse((_bootstrap.DataProviderResponses ?? EmptyResponse).Where(w => w.Handled),
            _bootstrap.DataProviderResponses.State(), request,
            DataProviderNoRecordState.Billable);
    }

        private async void CreateTransaction(ICollection<IPointToLaceRequest> request, DataProviderResponseState state)
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