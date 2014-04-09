using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Lace.Models.Ivid;
using Lace.Models.Ivid.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.ServiceSetup;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidService : IRequestDataFromService
    {

        private ILaceRequest _request;

        public void FetchDataFromService(ILaceRequest request, ILaceResponse response)
        {
            _request = request;
            response.IvidResponse = new IvidResponse();
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
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
