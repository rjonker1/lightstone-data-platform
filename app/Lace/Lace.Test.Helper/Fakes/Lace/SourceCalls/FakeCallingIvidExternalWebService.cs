﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Test.Helper.Builders.Responses;

namespace Lace.Test.Helper.Fakes.Lace.SourceCalls
{
    public class FakeCallingIvidExternalWebService : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _ividResponse = new SourceResponseBuilder().ForIvid();
            TransformResponse(response);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
