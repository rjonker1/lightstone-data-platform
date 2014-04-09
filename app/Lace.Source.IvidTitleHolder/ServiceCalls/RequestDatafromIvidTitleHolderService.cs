using System;
using Common.Logging;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class RequestDatafromIvidTitleHolderService : IRequestDataFromService
    {
        private static readonly ILog Log = LogManager.GetLogger<RequestDatafromIvidTitleHolderService>();

        private ILaceRequest _request;
        public void FetchDataFromService(ILaceRequest request, ILaceResponse response)
        {
            _request = request;

            CallIvidTitleHolderService();



            //response.IvidTitleHolderResponse = new IvidTitleHolderResponse();
            //response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            //response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }

        private void CallIvidTitleHolderService()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid TitleHolder Web Service {0}", ex.Message);
                //throw;
            }
        }
    }
}
