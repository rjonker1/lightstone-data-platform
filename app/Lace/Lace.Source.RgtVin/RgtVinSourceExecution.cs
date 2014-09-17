﻿using Lace.Consumer;
using Lace.Events;
using Lace.Models;
using Lace.Models.RgtVin;
using Lace.Request;
using Lace.Source.Enums;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinSourceExecution : ExecuteSourceBase, IExecuteTheSource
    {
        private readonly ILaceRequest _request;

        public RgtVinSourceExecution(ILaceRequest request, IExecuteTheSource nextSource,
            IExecuteTheSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            var spec = new CanHandlePackageSpecification(Services.RgtVin, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new HandleRgtVinSourceCall(), new CallRgtVinExternalSource(_request));
                consumer.ConsumeExternalSource(response, laceEvent);

                if (response.RgtVinResponse == null && FallBack != null)
                    CallFallbackSource(response, laceEvent);
            }

            CallNextSource(response, laceEvent);

        }

        private static void NotHandledResponse(IProvideLaceResponse response)
        {
            response.RgtVinResponse = null;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasNotBeenHandled();
        }
    }
}
