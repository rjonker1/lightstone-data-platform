using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IBus _bus;
        private readonly ISendMonitoringMessages _monitoring;
        private IBuildSourceChain _sourceChain;
        private IBootstrap _bootstrap;

        public EntryPointService(IBus bus)
        {
            _bus = bus;
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                //_monitoring = new MonitoringMessageSender(_bus, request.RequestAggregation.AggregateId);
                _sourceChain = new CreateSourceChain(request.Package);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    Log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return EmptyResponse;

                _bootstrap = new Initialize(new LaceResponse(), request, _bus, _sourceChain);
                _bootstrap.Execute();

                return _bootstrap.LaceResponses ?? EmptyResponse;

            }
            catch (Exception ex)
            {
                _monitoring.DataProviderFault(DataProviderCommandSource.EntryPoint, string.Format("Error {0}", ex.Message),
                    request.ObjectToJson());
                Log.ErrorFormat("Error occurred receiving request {0}",
                    request.ObjectToJson());
                return EmptyResponse;
            }
        }

        private static IList<LaceExternalSourceResponse> EmptyResponse
        {
            get
            {
                return new List<LaceExternalSourceResponse>()
                {
                    new LaceExternalSourceResponse()
                    {
                        Response = new LaceResponse()
                        {

                        }
                    }
                };
            }
        }
    }
}
