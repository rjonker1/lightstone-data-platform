using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtDataProvider : ICallTheDataProviderSource
    {
        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            //TODO: Add stubbed data for response
            TransformResponse(response,monitoring);
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendCommandsToBus monitoring)
        {
            var transformer = new TransformRgtResponse(new List<CarSpecification>());

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.RgtResponse = transformer.Result;
            response.RgtResponseHandled = new RgtResponseHandled();
            response.RgtResponseHandled.HasBeenHandled();
        }
    }
}
