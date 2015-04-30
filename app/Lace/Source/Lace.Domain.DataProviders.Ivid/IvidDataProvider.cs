using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Ivid
{
    public class IvidDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public IvidDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
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
                var stopWatch = new StopWatchFactory().StopWatchForDataProvider(DataProviderCommandSource.Ivid);
                _command.Workflow.Begin(new {_request }, stopWatch, DataProviderCommandSource.Ivid);

                var consumer = new ConsumeSource(new HandleIvidSourceCall(), new CallIvidDataProvider(_request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Ivid)));
                consumer.ConsumeExternalSource(response, _command);

                _command.Workflow.End(response, stopWatch, DataProviderCommandSource.Ivid);

               if(!response.OfType<IProvideDataFromIvid>().Any() || response.OfType<IProvideDataFromIvid>().First() == null)
                   CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }


        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasNotBeenHandled();
            response.Add(ividResponse);
        }
    }
}
