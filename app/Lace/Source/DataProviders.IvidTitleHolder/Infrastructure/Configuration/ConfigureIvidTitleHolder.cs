using System;
using System.ServiceModel.Channels;
using Lace.Domain.DataProviders.Core.Configuration;
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

            Client.ClientCredentials.UserName.UserName = IvidTitleHolderConfiguration.Username;
            Client.ClientCredentials.UserName.Password = IvidTitleHolderConfiguration.Password;
        }

        private void ConfigureRequestMessageProperty()
        {
            RequestMessageProperty =
                AuthenticationHeaders.CreateBasicHttpRequestMessageProperty(
                    IvidTitleHolderConfiguration.Username, IvidTitleHolderConfiguration.Password);
        }

        public void Close()
        {
            if (Client == null) return;

            Client.Close();
        }
    }
}
