using System;
using System.ServiceModel.Channels;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration
{
    public class ConfigureIvidSource
    {
        public HpiServiceClient IvidServiceProxy { get; private set; }
        public HttpRequestMessageProperty IvidRequestMessageProperty { get; private set; }

        public void ConfigureIvidWebServiceCredentials()
        {
            IvidServiceProxy = new HpiServiceClient();

            if (IvidServiceProxy == null || IvidServiceProxy.ClientCredentials == null)
                throw new Exception("Cannot configure IVID Web Service");

            IvidServiceProxy.ClientCredentials.UserName.UserName = Credentials.IvidServiceUsername();
            IvidServiceProxy.ClientCredentials.UserName.Password = Credentials.IvidServiceUserPassword();
        }

        public void ConfigureIvidWebServiceRequestMessageProperty()
        {
            IvidRequestMessageProperty =
                AuthenticationHeaders.CreateBasicHttpRequestMessageProperty(Credentials.IvidServiceUsername(),
                    Credentials.IvidServiceUserPassword());
        }

        public void CloseWebService()
        {
            if (IvidServiceProxy == null) return;

            IvidServiceProxy.Close();
        }
    }
}
