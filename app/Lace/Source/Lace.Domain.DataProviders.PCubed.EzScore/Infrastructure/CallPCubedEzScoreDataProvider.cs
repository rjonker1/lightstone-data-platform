using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure
{
    public sealed class CallPCubedEzScoreDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public CallPCubedEzScoreDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling PCubed EzScore Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling  PCubed EzScore Data Provider" });
                PCubedEzScoreResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformPCubedEzScoreResponse();

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void PCubedEzScoreResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ezScoreResponse = new PCubedEzScoreResponse();
            ezScoreResponse.HasBeenHandled();
            response.Add(ezScoreResponse);
        }
    }
}
