using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Infrastructure.Management;
using Lace.Shared.DataProvider.Models;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingRgtDataProvider : ICallTheDataProviderSource
    {
        private readonly ISendCommandToBus _command;

        public FakeCallingRgtDataProvider(ISendCommandToBus command)
        {
            _command = command;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            //TODO: Add stubbed data for response
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
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
