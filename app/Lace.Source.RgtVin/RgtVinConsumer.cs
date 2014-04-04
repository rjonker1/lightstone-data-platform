using Lace.Request;
using Lace.Response;
using System;
using Lace.Source.RgtVin.ServiceCalls;

namespace Lace.Source.RgtVin
{
    public class RgtVinConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;

        public RgtVinConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleRgtVinServiceCall();
        }


        public ILaceResponse CallRgtVinService()
        {
            return _handleServiceCall.Call(c =>
                c.FetchDataFromService(_request)
                );
        }
    }

    //class RgtVin : ISource
    //{
    //    public string SourceName
    //    {
    //        get
    //        {
    //            return GetType().Name;
    //        }
    //    }

    //    //public IvidTitleHolder(ISource source)
    //    //{
    //    //    Next = source;
    //    //}

    //    public ISource Next { get; set; }

    //    public void Append(ISource source)
    //    {
    //        if (Next == null)
    //        {
    //            Next = source;
    //        }
    //        else
    //        {
    //            Next.Append(source);
    //        }
    //    }

    //    public bool Handles(ILaceRequest request)
    //    {
    //        return request.Sources.Contains(SourceName);
    //    }

    //    public ILaceResponse CallService(ILaceRequest reqeust)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
