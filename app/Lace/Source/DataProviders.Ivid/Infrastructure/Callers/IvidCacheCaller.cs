using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Repositories;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Callers
{
    public class IvidCacheCaller : AbstractIvidCaller, ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<IvidCacheCaller>();

        private readonly HpiStandardQueryRequest _request;
        private readonly ILogCommandTypes _logCommand;
        private IProvideDataFromIvid _cacheResponse;
        private readonly IAmDataProvider _dataProvider;

        public IvidCacheCaller(ICallTheDataProviderSource next, HpiStandardQueryRequest request, IAmDataProvider dataProvider, ILogCommandTypes logCommand) 
            : base(next)
        {
            _logCommand = logCommand;
            _request = request;
            _dataProvider = dataProvider;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var parameter = GetCacheSearch(_request);
                if (string.IsNullOrEmpty(parameter))
                    CallNext(response);

                _cacheResponse = DataProviderRepository.GetKeyFromCache<IvidResponse>(string.Format(IvidResponse.CacheKey, parameter));

                if (_cacheResponse != null)
                {
                    _logCommand.LogRequest(new ConnectionTypeIdentifier("localhost").ForCacheType(), _request,
                        _dataProvider.BillablleState.NoRecordState);

                    _logCommand.LogResponse(DataProviderResponseState.Successful, new ConnectionTypeIdentifier("localhost").ForCacheType(),
                        _cacheResponse, _dataProvider.BillablleState.NoRecordState);

                    _logCommand.LogTransformation(_cacheResponse, new {CacheResponse = "Response retrieved from Ivid's Cache"});
                    _cacheResponse.HasBeenHandled();
                    response.Add(_cacheResponse);
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Cannot get Ivid Data from the cache because of {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error getting Ivid data from the cache" });
            }

            if (!response.HasRecords<IProvideDataFromIvid>()) CallNext(response);
        }

        private static string GetCacheSearch(HpiStandardQueryRequest request)
        {
            var type = request.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => CacheableRequestFields.Contains(w.Name));
            var value = properties.OrderByDescending(o => o.Name).Select(s => s.GetValue(request, null)).FirstOrDefault(w => !w.IsNullOrEmpty());
            return value == null ? string.Empty : value.ToString();
        }

        private static readonly IEnumerable<string> CacheableRequestFields = new List<string>()
        {
            "VinOrChassis",
            "LicenceNo",
            "RegisterNo"
        };


        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            throw new NotImplementedException();
        }
    }
}
