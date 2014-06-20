using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Lace.Builder.RequestTypes;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder.Specifications
{
    public class SourceSpecification : ISourceSpecification
    {

        private readonly ILaceRequest _request;

        public SourceSpecification(ILaceRequest request)
        {
            _request = request;
        }

        public IDictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> Specifications
        {
            get { throw new NotImplementedException(); }
        }

        private static IDictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> _specification
        {
            get
            {
                return new Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>>()
                {
                    {typeof(IRequestUsingLicensePlateNumber), (req, evt, resp) => new IvidConsumer(req).CallIvidService(resp, evt)},
                    {
                        typeof(IRequestUsingLicensePlateNumber),
                        (req, evt, resp) =>
                            new IvidTitleHolderConsumer(req).CallIvidTitleHolderService(resp, evt)
                    },
                    {typeof(IRequestUsingLicensePlateNumber), (req, evt, resp) => new RgtVinConsumer(req).CallRgtVinService(resp, evt)},
                    {typeof(IRequestUsingLicensePlateNumber), (req, evt, resp) => new AudatexConsumer(req).CallAudatexService(resp, evt)}
                };
            }
        }

       
    }

    


}
