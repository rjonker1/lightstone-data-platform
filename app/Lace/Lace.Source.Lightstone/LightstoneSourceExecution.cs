﻿using Lace.Consumer;
using Lace.Events;
using Lace.Models;
using Lace.Models.Lightstone;
using Lace.Request;
using Lace.Source.Enums;
using Lace.Source.Lightstone.Repository.Factory;
using Lace.Source.Lightstone.Repository.Infrastructure;
using Lace.Source.Lightstone.SourceCalls;

namespace Lace.Source.Lightstone
{
    public class LightstoneSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public LightstoneSourceExecution(ILaceRequest request, IExecuteTheSource nextSource,
            IExecuteTheSource fallbackSource) : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.Lightstone, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleLightstoneSourceCall(),
                    new CallLightstoneExternalSource(_request,
                        new RepositoryFactory(ConnectionFactory.ForAutoCarStatsDatabase(),
                            CacheConnectionFactory.LocalClient())));

                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.LightstoneResponse == null)
                    CallFallbackSource(response, laceEvent);
            }
        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.LightstoneResponse = null;
            response.LightstoneResponseHandled = new LightstoneResponseHandled();
            response.LightstoneResponseHandled.HasNotBeenHandled();
        }
    }
}
