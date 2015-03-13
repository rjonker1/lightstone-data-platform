﻿using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeIvidSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {

        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;

        public FakeIvidSourceExecution(ILaceRequest request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendMonitoringCommandsToBus monitoring)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _monitoring = monitoring;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.Ivid, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleIvidServiceCall(),
                    new FakeCallingIvidExternalWebService());
                consumer.ConsumeExternalSource(response, _monitoring);

                if (!response.OfType<IProvideDataFromIvid>().Any() || response.OfType<IProvideDataFromIvid>().First() == null)
                    CallFallbackSource(response, _monitoring);
            }

            CallNextSource(response, _monitoring);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasNotBeenHandled();
            response.Add(ividResponse);
        }

    }
}
