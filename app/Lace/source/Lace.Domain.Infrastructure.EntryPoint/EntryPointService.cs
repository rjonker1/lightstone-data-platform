using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Sources.Lace;
using Workflow;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private ISendMonitoringMessages _monitoring;
        private readonly IPublishMessages _publisher;
        private IBuildSourceChain _sourceChain;
        private IBootstrap _bootstrap;

        public EntryPointService(IPublishMessages publisher)
        {
            _publisher = publisher;
            _checkForDuplicateRequests = new CheckTheReceivedRequest();
        }

        public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
        {
            try
            {
                //_monitoring = new PublishLaceEventMessages(_publisher, request.RequestAggregation.AggregateId);

                //_monitoring.PublishLaceReceivedRequestMessage(LaceEventSource.EntryPoint);


                _sourceChain = new CreateSourceChain(request.Package);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    Log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request)) return EmptyResponse;

                _bootstrap = new Initialize(new LaceResponse(), request, _monitoring, _sourceChain);
                _bootstrap.Execute();

                return _bootstrap.LaceResponses ?? EmptyResponse;

            }
            catch (Exception)
            {
                //_monitoring.PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(LaceEventSource.EntryPoint);
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
