using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.Metadata.DataProviders.Ivid
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
            var spec = new CanHandlePackageSpecification(DataProviderName.IVIDVerify_E_WS, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleIvidServiceCall(),
                    new FakeCallingIvidExternalWebService());
                consumer.ConsumeDataProvider(response);

                if (!response.HasRecords<IProvideDataFromIvid>())CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);

        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = IvidResponse.Empty();
            ividResponse.HasNotBeenHandled();
            response.Add(ividResponse);
        }
    }
}