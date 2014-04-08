using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Lace.Request;
using Lace.Response;
using Lace.Source.Enums;
using Lace.Source.Ivid.ServiceSetup;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class HandleIvidServiceCall : IHandleServiceCall
    {
        public Services Service
        {
            get
            {
                return Services.Ivid;
            }
        }

        private readonly ILaceRequest _request;

        public HandleIvidServiceCall(ILaceRequest request)
        {
            _request = request;
        }


        public bool CanHandle(ILaceRequest request)
        {
            return request.Sources.Contains(Service.ToString());
        }

        public ILaceResponse Call(Action<IRequestDataFromService> action)
        {
            //return new IvidServiceResponse()
            //{
            //    Handled = true,
            //    Response = new List<string>() { "Handle Ivid Service Call" }
            //};
            return null;
        }

        private void CallIvidWebService()
        {
            var ividWebService = new SetupIvidWebService();
            using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    ividWebService.IvidRequestMessageProperty;

                var ividRequest = new SetupIvidQueryRequestMessage(_request)
                    .HpiQueryRequest;

                //TODO: Need to Log the request to the database
                //LogServiceReqeust(ividRequest);

                var response = ividWebService
                    .IvidServiceProxy
                    .HpiStandardQuery(ividRequest);


                if (response == null || !response.partialResponse)
                    throw new Exception("LACE: Ivid Service call was not successfull");




            }
        }

        

        private static void LogServiceReqeust(string request)
        {
            //TODO: Implement
        }
    }
}
