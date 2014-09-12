using System;
using Common.Logging;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Monitoring.Sources.Lace;

namespace Lace.Source.Anpr.SourceCalls
{
    public class CallAnprExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const LaceEventSource Source = LaceEventSource.Anpr;

        private readonly ILaceRequest _request;

        public CallAnprExternalSource(ILaceRequest request)
        {
            _request = request;
        }


        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            throw new NotImplementedException();
        }

        public void TransformResponse(ILaceResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
