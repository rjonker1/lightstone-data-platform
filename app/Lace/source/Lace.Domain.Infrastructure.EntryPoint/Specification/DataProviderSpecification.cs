using System;
using System.Collections.Generic;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Audatex;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.RgtVin;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        private readonly Func<Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>
            _defaultLicenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new IvidDataProvider(request,
                            new LightstoneDataProvider(request,
                                new IvidTitleHolderDataProvider(request,
                                    new RgtVinDataProvider(request,
                                        new AudatexDataProvider(request, null, null), null),
                                    null), null), null).CallSource(response, @event);

        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, IProvideResponseFromLaceDataProviders>>()
                {
                    {
                        "License plate search", _defaultLicenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
