using System.Collections.Generic;
using System.Linq;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using System;
using Lace.Source.Enums;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class HandleIvidTitleHolderServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.IvidTitleHolder;
            }
        }

        private bool _canHandle;
        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
            _canHandle = request.Sources.Contains(Service.ToString());

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }

        public void Call(Action<IRequestDataFromService> action)
        {
            action.Invoke(new RequestDatafromIvidTitleHolderService());
          
            //return Helpers.ConvertFunctions.ConvertObject<Type>(response);
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasNotBeenHandled();
        }
    }
}
