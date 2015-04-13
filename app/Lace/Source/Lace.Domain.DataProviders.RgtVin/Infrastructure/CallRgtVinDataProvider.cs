using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Dto;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Domain.DataProviders.RgtVin.UnitOfWork;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class CallRgtVinDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.RgtVin;

        private readonly ISetupRepository _repository;
        private IList<Vin> _vins;


        public CallRgtVinDataProvider(ICollection<IPointToLaceRequest> request, ISetupRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            try
            {
                var vin = new RgtVinRequestMessage(response)
                    .Build()
                    .Vin;

                command.Workflow.Send(CommandType.Configuration, new {VinNumber = vin}, null, Provider);

                command.Workflow.DataProviderRequest(Provider,
                    "Database", ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString, DataProviderAction.Request,
                    DataProviderState.Successful, new { vin }, _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                var uow = new VehicleVinUnitOfWork(_repository.VinRepository());
                uow.GetVin(vin);
                _vins = uow.Vins != null ? uow.Vins.ToList() : new List<Vin>();

                command.Workflow.DataProviderResponse(Provider,
                    "Database", ConnectionFactory.ForAutoCarStatsDatabase().ConnectionString,
                    DataProviderAction.Response,
                    _vins.Any() ? DataProviderState.Successful : DataProviderState.Failed,
                    new { _vins }, _stopWatch, _request.GetFromRequest<IAmDataProvider>().CostPrice, _request.GetFromRequest<IAmDataProvider>().RecommendedPrice);

                if (_vins == null || !_vins.Any())
                    command.Workflow.Send(CommandType.Fault, new {VinNumber = vin},
                        new {ErrorMessage = "No VINs were received"}, Provider);

                TransformResponse(response, command);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling RGT Vin Data Provider {0}", ex.Message);
                command.Workflow.Send(CommandType.Fault, ex.Message,
                    new {ErrorMessage = "Error calling RGT Vin Data Provider"}, Provider);
                RgtVinResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformRgtVinResponse(_vins);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            command.Workflow.Send(CommandType.Transformation, transformer.Result, transformer, Provider);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void RgtVinResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var rgtVinResponse = new RgtVinResponse();
            rgtVinResponse.HasBeenHandled();
            response.Add(rgtVinResponse);
        }
    }
}