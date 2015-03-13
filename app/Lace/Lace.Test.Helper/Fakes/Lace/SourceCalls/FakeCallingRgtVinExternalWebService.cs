﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Domain.DataProviders.RgtVin.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtVinExternalWebService : ICallTheDataProviderSource
    {

        private IEnumerable<Vin> _vin;

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            _vin = new SourceResponseBuilder().ForRgtVin();
            TransformResponse(response, monitoring);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformRgtVinResponse(_vin);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
