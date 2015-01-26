using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class EntryPointService : IEntryPoint
    {
        private readonly ICheckForDuplicateRequests _checkForDuplicateRequests;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IBus _bus;
        private ISendCommandsToBus _monitoring;
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
                _monitoring = new SendEntryPointCommands(_bus, request.RequestAggregation.AggregateId,
                    (int) ExecutionOrder.First);

                _monitoring.Begin(request, null);

                _sourceChain = new CreateSourceChain(request.Package);
                _sourceChain.Build();

                if (_sourceChain.SourceChain == null)
                {
                    Log.ErrorFormat("Source chain could not be built for action {0}", request.Package.Action.Name);
                    _monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            ChainBuilderError =
                                string.Format("Source chain could not be built for action {0}",
                                    request.Package.Action.Name)
                        });
                    _monitoring.End(request, null);
                    return EmptyResponse;
                }

                if (_checkForDuplicateRequests.IsRequestDuplicated(request))
                {
                    _monitoring.Send(CommandType.Fault, request,
                        new
                        {
                            DuplicateRequest = "This Request is duplicated and will not be executed"
                        });
                    _monitoring.End(request, null);
                    return EmptyResponse;
                }

                _bootstrap = new Initialize(new LaceResponse(), request, _bus, _sourceChain);
                _bootstrap.Execute();

                _monitoring.End(_bootstrap.LaceResponses ?? EmptyResponse, null);

                return _bootstrap.LaceResponses ?? EmptyResponse;

            }
            catch (Exception ex)
            {
                _monitoring.Send(CommandType.Fault, ex.Message, request);
                _monitoring.End(request, null);
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
