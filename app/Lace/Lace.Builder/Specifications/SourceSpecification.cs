﻿using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.Lightstone;
using Lace.Source.RgtVin;

namespace Lace.Builder.Specifications
{
    public class SourceSpecification
    {

        private readonly Func<Action<ILaceRequest, ILaceEvent, ILaceResponse>>
            _defaultLicenseNumberRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new IvidSourceExecution(request,
                            new IvidTitleHolderSourceExecution(request,
                                new RgtVinSourceExecution(request,
                                    new AudatexSourceExecution(request, null, null), null),
                                null), null).CallSource(response, @event);



        private readonly Func<Action<ILaceRequest, ILaceEvent, ILaceResponse>>
            _lightstoneRequestSpecification =
                () =>
                    (request, @event, response) =>
                        new LightstoneSourceExecution(request, null, null).CallSource(response, @event);

        public IEnumerable<KeyValuePair<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> Specifications
        {
            get
            {
                return new Dictionary<string, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {
                        "License plate search", _defaultLicenseNumberRequestSpecification()
                    }
                };
            }
        }
    }
}
