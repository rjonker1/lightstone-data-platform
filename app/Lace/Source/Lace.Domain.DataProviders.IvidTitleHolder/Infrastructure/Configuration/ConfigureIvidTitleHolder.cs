using System;
using System.ServiceModel.Channels;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration
{
    public class ConfigureIvidTitleHolder
    {
        public IvidTitleholderServiceClient Client { get; private set; }
        public HttpRequestMessageProperty RequestMessageProperty { get; private set; }

        public ConfigureIvidTitleHolder()
        {
            ConfigureCredentials();
            ConfigureRequestMessageProperty();
        }

        private void ConfigureCredentials()
        {
            Client = new IvidTitleholderServiceClient();

            if (Client == null || Client.ClientCredentials == null)
                throw new Exception("Cannot configure Ivid Title Holder Service");

            Client.ClientCredentials.UserName.UserName = Credentials.IvidTitleHolderServiceUserName();
            Client.ClientCredentials.UserName.Password = Credentials.IvidTitleHolderServiceUserPassword();
        }

        private void ConfigureRequestMessageProperty()
        {
            RequestMessageProperty =
                AuthenticationHeaders.CreateBasicHttpRequestMessageProperty(
                    Credentials.IvidTitleHolderServiceUserName(), Credentials.IvidTitleHolderServiceUserPassword());
        }

        public void Close()
        {
            if (Client == null) return;

            Client.Close();
        }
    }
}
