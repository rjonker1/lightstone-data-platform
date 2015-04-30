using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.IvidTitleHolder
{
    public class IvidTitleHolderDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public IvidTitleHolderDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
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
                var stopWatch =
                    new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.IvidTitleHolder);
                _command.Workflow.Begin(new { _request, IvidResponse = response.OfType<IProvideDataFromIvid>().First() }, stopWatch, DataProviderCommandSource.IvidTitleHolder);

                var consumer = new ConsumeSource(new HandleIvidTitleHolderSourceCall(),
                    new CallIvidTitleHolderDataProvider(_request));
                consumer.ConsumeDataProvider(response);

                _command.Workflow.End(response, stopWatch, DataProviderCommandSource.IvidTitleHolder);

                if (!response.OfType<IProvideDataFromIvidTitleHolder>().Any() || response.OfType<IProvideDataFromIvidTitleHolder>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = new IvidTitleHolderResponse();
            ividTitleHolderResponse.HasNotBeenHandled();
            response.Add(ividTitleHolderResponse);
        }
    }
}
