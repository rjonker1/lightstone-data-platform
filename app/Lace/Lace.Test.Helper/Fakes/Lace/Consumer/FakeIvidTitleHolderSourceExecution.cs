﻿using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeIvidTitleHolderSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public FakeIvidTitleHolderSourceExecution(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.IvidTitleHolder, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleIvidTitleHolderServiceCall(),
                    new FakeCallingIvidTitleHolderExternalWebService());
                consumer.ConsumeExternalSource(response, _command);

                if (!response.OfType<IProvideDataFromIvidTitleHolder>().Any() ||
                    response.OfType<IProvideDataFromIvid>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleResponse = new IvidTitleHolderResponse();
            ividTitleResponse.HasNotBeenHandled();
            response.Add(ividTitleResponse);
        }
    }
}
