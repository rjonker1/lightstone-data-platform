using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Models;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;
using Lace.Source.Lightstone;

namespace Lace.Builder.Specifications
{
    public class SourceSpecification
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
