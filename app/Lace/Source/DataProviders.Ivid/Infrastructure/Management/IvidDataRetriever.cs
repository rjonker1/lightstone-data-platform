﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Repositories;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public sealed class IvidDataRetriever
    {
        private readonly ILogCommandTypes _logCommand;
        private readonly ILog _log;

        private IvidDataRetriever(ILogCommandTypes logCommand, ILog log)
        {
            _logCommand = logCommand;
            _log = log;
        }

        public static IvidDataRetriever Start(ILogCommandTypes logCommand, ILog log)
        {
            return new IvidDataRetriever(logCommand, log);
        }

        public IvidDataRetriever CheckInCache(HpiStandardQueryRequest request)
        {
            try
            {
                var parameter = GetCacheSearch(request);
                if (string.IsNullOrEmpty(parameter))
                    return this;

                CacheResponse = DataProviderRepository.GetKeyFromCache<IvidResponse>(string.Format(IvidResponse.CacheKey, parameter));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot get Ivid Data from the cache because of {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error getting Ivid data from the cache" });
            }

            return this;
        }

        public IvidDataRetriever ThenWithApi(HpiStandardQueryRequest request, IAmDataProvider dataProvider,
            out HpiStandardQueryResponse response)
        {
            if (NoNeedToCallApi)
            {
                response = null;
                return this;
            }

            var webService = new ConfigureIvid();

            _logCommand.LogSecurity(
                new
                {
                    Credentials =
                        new
                        {
                            webService.Client.ClientCredentials.UserName.UserName,
                            webService.Client.ClientCredentials.UserName.Password
                        }
                },
                new {ContextMessage = "Ivid Data Provider Credentials"});

            using (var scope = new OperationContextScope(webService.Client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    webService.RequestMessageProperty;

                _logCommand.LogConfiguration(request, null);
                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                    .ForWebApiType(), request, dataProvider.BillablleState.NoRecordState);

                response = webService
                    .Client
                    .HpiStandardQuery(request);

                webService.CloseWebService();

                _logCommand.LogResponse(CheckState(response),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), response ?? new HpiStandardQueryResponse(), dataProvider.BillablleState.NoRecordState);

                if (response == null)
                    _logCommand.LogFault(dataProvider,
                        new {NoRequestReceived = "No response received from Ivid Data Provider"});
            }

            return this;
        }

        private static DataProviderResponseState CheckState(HpiStandardQueryResponse response)
        {
            return response == null
                ? DataProviderResponseState.NoRecords
                : response.partialResponse ? DataProviderResponseState.Partial : DataProviderResponseState.Successful;
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

        public IProvideDataFromIvid CacheResponse { get; private set; }
        public HpiStandardQueryResponse Response { get; private set; }

        public bool NoNeedToCallApi
        {
            get
            {
                return CacheResponse != null;
            }
        }
    }

    
}

