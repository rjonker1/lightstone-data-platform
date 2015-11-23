using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Callers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public sealed class CallIvidDataProvider : AbstractIvidCaller, ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallIvidDataProvider>();
        private readonly ILogCommandTypes _logCommand;

        public CallIvidDataProvider(ICallTheDataProviderSource next, ILogCommandTypes logCommand) : base(next)
        {
          
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                CallNext(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling Ivid Data Provider" });
                IvidResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
           
        }

        private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = IvidResponse.WithState(DataProviderResponseState.TechnicalError);
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }
    }
}