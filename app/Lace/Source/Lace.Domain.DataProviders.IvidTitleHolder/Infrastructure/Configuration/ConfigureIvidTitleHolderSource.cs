using System;
using System.ServiceModel.Channels;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration
{
    public class ConfigureIvidTitleHolderSource
    {
        public IvidTitleholderServiceClient IvidTitleHolderProxy { get; private set; }
        public HttpRequestMessageProperty IvidTitleHolderRequestMessageProperty { get; private set; }

        public ConfigureIvidTitleHolderSource()
        {
            ConfigureIvidTitleHolderServiceCredentials();
            ConfigureIvidTitleHolderWebServiceRequestMessageProperty();
        }

        private void ConfigureIvidTitleHolderServiceCredentials()
        {
            IvidTitleHolderProxy = new IvidTitleholderServiceClient();

            if (IvidTitleHolderProxy == null || IvidTitleHolderProxy.ClientCredentials == null)
                throw new Exception("Cannot configure Ivid Title Holder Service");

            IvidTitleHolderProxy.ClientCredentials.UserName.UserName = Credentials.IvidTitleHolderServiceUserName();
            IvidTitleHolderProxy.ClientCredentials.UserName.Password = Credentials.IvidTitleHolderServiceUserPassword();
        }

        private void ConfigureIvidTitleHolderWebServiceRequestMessageProperty()
        {
            IvidTitleHolderRequestMessageProperty =
                AuthenticationHeaders.CreateBasicHttpRequestMessageProperty(
                    Credentials.IvidTitleHolderServiceUserName(), Credentials.IvidTitleHolderServiceUserPassword());
        }

        public void CloseWebService()
        {
            if (IvidTitleHolderProxy == null) return;

            IvidTitleHolderProxy.Close();
        }
    }
}
