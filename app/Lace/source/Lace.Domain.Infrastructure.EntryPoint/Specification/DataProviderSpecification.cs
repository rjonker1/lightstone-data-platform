using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        private readonly Func<Action<ILaceRequest, ISendMonitoringMessages, IProvideResponseFromLaceDataProviders>>
            _defaultLicenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new IvidDataProvider(request,
                            new LightstoneDataProvider(request,
                                new IvidTitleHolderDataProvider(request,
                                    new RgtVinDataProvider(request,
                                        new AudatexDataProvider(request, null, null), null),
                                    null), null), null).CallSource(response, @event);

        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ISendMonitoringMessages, IProvideResponseFromLaceDataProviders>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ISendMonitoringMessages, IProvideResponseFromLaceDataProviders>>()
                {
                    {
                        "License plate search", _defaultLicenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
