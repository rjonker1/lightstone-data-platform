﻿using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.IvidTitleHolder
{
    public class IvidTitleHolderDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ILaceRequest _request;

        public IvidTitleHolderDataProvider(ILaceRequest request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource)
            : base(nextSource, fallbackSource)
        {
            _request = request;
        }

        public void CallSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.IvidTitleHolder, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.IvidTitleHolder);
                monitoring.StartDataProvider(DataProviderCommandSource.IvidTitleHolder, _request.ObjectToJson(), stopWatch);

                var consumer = new ConsumeSource(new HandleIvidTitleHolderSourceCall(),
                    new CallIvidTitleHolderDataProvider(_request));
                consumer.ConsumeExternalSource(response, monitoring);

                monitoring.EndDataProvider(DataProviderCommandSource.IvidTitleHolder, _request.ObjectToJson(), stopWatch);

                if (response.IvidTitleHolderResponse == null)
                    CallFallbackSource(response, monitoring);
            }

            CallNextSource(response, monitoring);
        }

        private static void NotHandledResponse(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasNotBeenHandled();
        }
    }
}
