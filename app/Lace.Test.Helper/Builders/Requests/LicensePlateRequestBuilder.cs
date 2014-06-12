using Lace.Request;
using Lace.Test.Helper.Mothers.Requests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateRequestBuilder
    {
        private ILaceRequest _request;


        //public LicensePlateRequestBuilder Build()
        //{
        //    return new LicensePlateRequestBuilder();
        //}

        public ILaceRequest ForIvid()
        {
            _request = new LicensePlateNumberIvidOnlyRequest();
            return _request;
        }

    }
}
