using System;
using Common.Logging;
using Lace.Events;
using Lace.Models;
using Lace.Request;
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

        public void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent)
        {
            throw new NotImplementedException();
        }

        public void TransformResponse(IProvideLaceResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
