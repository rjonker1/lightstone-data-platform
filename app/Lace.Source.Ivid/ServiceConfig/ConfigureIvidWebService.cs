using System;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using Lace.Source.Ivid.IvidServiceReference;

namespace Lace.Source.Ivid.ServiceConfig
{
    public class ConfigureIvidWebService
    {
        private readonly string _userName = System.Configuration.ConfigurationManager.AppSettings["IvidServiceUserName"];

        private readonly string _userPassowrd =
            System.Configuration.ConfigurationManager.AppSettings["IvidServiceUserPassword"];

        public HpiServiceClient IvidServiceProxy { get; private set; }
        public HttpRequestMessageProperty IvidRequestMessageProperty { get; private set; }

        public void ConfigureIvidWebServiceCredentials()
        {
            IvidServiceProxy = new HpiServiceClient();

            if (IvidServiceProxy == null || IvidServiceProxy.ClientCredentials == null)
                throw new Exception("Cannot configure IVID Web Service");

            IvidServiceProxy.ClientCredentials.UserName.UserName = _userName;
            IvidServiceProxy.ClientCredentials.UserName.Password = _userPassowrd;
        }

        public void ConfigureIvidWebServiceRequestMessageProperty()
        {
            IvidRequestMessageProperty = new HttpRequestMessageProperty();
            IvidRequestMessageProperty
                .Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _userName, _userPassowrd))));

        }

        public void CloseWebService()
        {
            if (IvidServiceProxy == null) return;

            IvidServiceProxy.Close();
        }


    }
}
