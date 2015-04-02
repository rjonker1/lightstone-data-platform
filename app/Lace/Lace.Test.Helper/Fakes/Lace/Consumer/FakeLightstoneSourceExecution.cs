using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Infrastructure;
using Lace.Test.Helper.Fakes.Lace.Handlers;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using Workflow.Lace.Messages.Core;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeLightstoneSourceExecution : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;

        public FakeLightstoneSourceExecution(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource,
            IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.LightstoneAuto, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                var consumer = new ConsumeSource(new FakeHandleLighstoneSourceCall(),
                    new CallLightstoneDataProvider(_request, new FakeRepositoryFactory(),new FakeCarRepositioryFactory()));
                consumer.ConsumeExternalSource(response, _command);

                if (!response.OfType<IProvideDataFromLightstoneAuto>().Any() || response.OfType<IProvideDataFromLightstoneAuto>().First() == null)
                    CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneResponseHandled = new LightstoneAutoResponse();
            lightstoneResponseHandled.HasNotBeenHandled();
            response.Add(lightstoneResponseHandled);
        }
    }
}
