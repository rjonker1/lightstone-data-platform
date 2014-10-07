using System;
using System.Collections.Generic;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Fakes.Lace.Consumer;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceSpecification
    {
        private readonly Func<Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>
            _licenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new FakeIvidSourceExecution(request,
                            new FakeLightstoneSourceExecution(request,
                                new FakeIvidTitleHolderSourceExecution(request,
                                    new FakeRgtVinSourceExecution(request,
                                        new FakeAudatexSourceExecution(request, null, null), null),
                                    null), null), null).CallSource(response, @event);


        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>()
                {
                    {
                        "License plate search", _licenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
