using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public sealed class CallIvidDataProvider : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _response;
        private HpiStandardQueryRequest _request;
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public CallIvidDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _request = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
                var data = IvidDataRetriever.Start(_logCommand, _log)
                    .CheckInCache(_request)
                    .ThenWithApi(_request, _dataProvider, out _response);

                if (data.NoNeedToCallApi)
                {
                    _logCommand.LogTransformation(data.CacheResponse, new {CacheResponse = "Response retrieved from Ivid's Cache"});
                    data.CacheResponse.HasBeenHandled();
                    response.Add(data.CacheResponse);
                    return;
                }

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Ivid Data Provider"});
                IvidResponseFailed(response);
            }
        }

        private void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = _dataProvider.IsCritical() ? IvidResponse.Failure(_dataProvider.Message()) : IvidResponse.Empty();
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidResponse(_response, _dataProvider.Critical);

            if (transformer.Continue)
            {
                transformer.Transform();
                transformer.SetStatusMessages(_request);
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
