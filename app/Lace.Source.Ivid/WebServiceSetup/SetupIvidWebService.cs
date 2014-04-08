using System;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Ivid.WebServiceSetup
{
    public class SetupIvidWebService
    {
        private readonly string _userName = System.Configuration.ConfigurationManager.AppSettings[""];
        private readonly string _userPassowrd = System.Configuration.ConfigurationManager.AppSettings[""];

        public HpiServiceClient IvidServiceProxy { get; private set; }
        public HttpRequestMessageProperty IvidRequestMessageProperty { get; private set; }

        public void SetupIvidWebServiceCredentials()
        {
            IvidServiceProxy = new HpiServiceClient();

            if(IvidServiceProxy == null || IvidServiceProxy.ClientCredentials == null)
                throw new Exception("LACE: Cannot setup IVID Web Service");

            IvidServiceProxy.ClientCredentials.UserName.UserName = _userName;
            IvidServiceProxy.ClientCredentials.UserName.Password = _userPassowrd;
        }

        public void SetupIvidWebServiceRequestMessageProperty()
        {
            IvidRequestMessageProperty = new HttpRequestMessageProperty();
            IvidRequestMessageProperty
                .Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _userName, _userPassowrd))));

        }


    }
}
