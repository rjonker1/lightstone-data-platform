using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtDataProvider : ICallTheDataProviderSource
    {
        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            //TODO: Add stubbed data for response
            TransformResponse(response, command);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendCommandToBus command)
        {
            var transformer = new TransformRgtResponse(new List<CarSpecification>());

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
