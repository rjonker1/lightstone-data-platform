using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Callers;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public sealed class CallIvidDataProvider : AbstractIvidCaller, ICallTheDataProviderSource
    {
        //private HpiStandardQueryResponse _response;
        //private HpiStandardQueryRequest _request;
        private static readonly ILog Log = LogManager.GetLogger<CallIvidDataProvider>();
        //private readonly IAmDataProvider _dataProvider;
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

        //public CallIvidDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        //{
        //    _dataProvider = dataProvider;
        //    _logCommand = logCommand;
        //}

        //public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        //{
        //    try
        //    {
        //        //_request = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());

        //        var data = IvidDataRetriever.Start(_logCommand, Log)
        //            .RetrieveFromCache(_request)
        //            .RetrieveFromApi(_request, _dataProvider, out _response);

        //        if (data.NoNeedToCallApi)
        //        {
        //            _logCommand.LogRequest(new ConnectionTypeIdentifier("localhost").ForCacheType(), _request,
        //                _dataProvider.BillablleState.NoRecordState);

        //            _logCommand.LogResponse(DataProviderResponseState.Successful, new ConnectionTypeIdentifier("localhost").ForCacheType(),
        //                data.CacheResponse, _dataProvider.BillablleState.NoRecordState);

        //            _logCommand.LogTransformation(data.CacheResponse, new {CacheResponse = "Response retrieved from Ivid's Cache"});
        //            data.CacheResponse.HasBeenHandled();
        //            response.Add(data.CacheResponse);
        //            return;
        //        }

        //        TransformResponse(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ErrorFormat("Error calling Ivid Data Provider {0}", ex, ex.Message);
        //        _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Ivid Data Provider"});
        //        IvidResponseFailed(response);
        //    }
        //}

        //private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        //{
        //    var ividResponse = IvidResponse.WithState(DataProviderResponseState.TechnicalError);
        //    ividResponse.HasBeenHandled();
        //    response.Add(ividResponse);
        //}

        //public void TransformResponse(ICollection<IPointToLaceProvider> response)
        //{
        //    var transformer = new TransformIvidResponse(_response);

        //    if (transformer.Continue)
        //    {
        //        transformer.Transform();
        //        transformer.SetStatusMessages(_request);
        //    }

        //    _logCommand.LogTransformation(transformer.Result, null);

        //    transformer.Result.HasBeenHandled();
        //    response.Add(transformer.Result);
        //}

        
    }
}