using System;
using System.Linq;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.ServiceCalls;

namespace Lace.Source.IvidTitleHolder
{
    public class IvidTitleHolderConsumer
    {
        private readonly IHandleServiceCall _handleServiceCall;
        private readonly ILaceRequest _request;


        public IvidTitleHolderConsumer(ILaceRequest request)
        {
            _request = request;
            _handleServiceCall = new HandleIvidTitleHolderServiceCall();
        }


        public ILaceResponse CallIvidTitleHolderService()
        {
           return _handleServiceCall.Call(c =>
                c.FetchDataFromService(_request)
                );
        }
    }

    //public class IvidTitleHolder : ISource
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
