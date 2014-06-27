using System;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using Lace.Source.Configuration;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.IvidTitleHolder.ServiceConfig
{
    public class ConfigureIvidTitleHolderSource
    {
       
        public IvidTitleholderServiceClient IvidTitleHolderProxy { get; private set; }
        public HttpRequestMessageProperty IvidTitleHolderRequestMessageProperty { get; private set; }

        public void ConfigureIvidTitleHolderServiceCredentials()
        {
            IvidTitleHolderProxy = new IvidTitleholderServiceClient();

            if (IvidTitleHolderProxy == null || IvidTitleHolderProxy.ClientCredentials == null)
                throw new Exception("Cannot configure Ivid Title Holder Service");

            IvidTitleHolderProxy.ClientCredentials.UserName.UserName = Credentials.IvidTitleHolderServiceUserName();
            IvidTitleHolderProxy.ClientCredentials.UserName.Password = Credentials.IvidTitleHolderServiceUserPassword();
        }

        public void ConfigureIvidTitleHolderWebServiceRequestMessageProperty()
        {
            IvidTitleHolderRequestMessageProperty = new HttpRequestMessageProperty();
            IvidTitleHolderRequestMessageProperty
                .Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Credentials.IvidTitleHolderServiceUserName(), Credentials.IvidTitleHolderServiceUserPassword()))));
        }

        public void CloseWebService()
        {
            if (IvidTitleHolderProxy == null) return;

            IvidTitleHolderProxy.Close();
        }
    }
}
