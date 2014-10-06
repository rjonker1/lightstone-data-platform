using System;
using System.Collections.Generic;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        private readonly Func<Action<ILaceRequest, ILaceEvent, IProvideLaceResponse>>
            _defaultLicenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new IvidSourceExecution(request,
                            new LightstoneSourceExecution(request,
                                new IvidTitleHolderSourceExecution(request,
                                    new RgtVinSourceExecution(request,
                                        new AudatexSourceExecution(request, null, null), null),
                                    null), null), null).CallSource(response, @event);

        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ILaceEvent, IProvideLaceResponse>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, IProvideLaceResponse>>()
                {
                    {
                        "License plate search", _defaultLicenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
