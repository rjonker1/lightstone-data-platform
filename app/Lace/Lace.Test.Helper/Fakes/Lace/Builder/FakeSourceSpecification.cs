using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Test.Helper.Fakes.Lace.Consumer;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceSpecification
    {
        private readonly Func<Action<ILaceRequest, ILaceEvent, ILaceResponse>>
            _licenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new FakeIvidSourceExecution(request,
                            new FakeIvidTitleHolderSourceExecution(request,
                                new FakeRgtVinSourceExecution(request,
                                    new FakeAudatexSourceExecution(request, null, null), null), 
                                null), null).CallSource(response, @event);


        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {
                        "License plate search", _licenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
