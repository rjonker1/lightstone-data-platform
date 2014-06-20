using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Builder.RequestTypes;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex;
using Lace.Source.Ivid;
using Lace.Source.IvidTitleHolder;
using Lace.Source.RgtVin;

namespace Lace.Builder.Specifications
{
    public class SourceSpecification : ISourceSpecification
    {

        private readonly ILaceRequest _request;

        public SourceSpecification(ILaceRequest request)
        {
            _request = request;
        }

        public IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> GetSpecificationForRequestType(IRequestType requestType)
        {

            return Specification.Where(w => w.Key.Equals(requestType));
        }

        private static IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> Specification
        {
            get
            {
                return new Dictionary<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {
                        typeof (IRequestUsingLicensePlateNumber),
                        (request, @event, response) =>
                            new IvidConsumer(request).CallSource(response, @event)
                    },
                    {
                        typeof (IRequestUsingLicensePlateNumber),
                        (request, @event, response) =>
                            new IvidTitleHolderConsumer(request).CallSource(response, @event)
                    },
                    {
                        typeof (IRequestUsingLicensePlateNumber),
                        (request, @event, response) => new RgtVinConsumer(request).CallSource(response, @event)
                    },
                    {
                        typeof (IRequestUsingLicensePlateNumber),
                        (request, @event, response) => new AudatexConsumer(request).CallSource(response, @event)
                    }
                };
            }
        }


    }

    


}
