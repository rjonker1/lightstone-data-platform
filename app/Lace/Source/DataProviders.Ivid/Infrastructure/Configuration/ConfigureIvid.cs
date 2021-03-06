﻿using System;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureIvid
    {
        [DataMember]
        public HpiServiceClient Client { get; private set; }
        [DataMember]
        public HttpRequestMessageProperty RequestMessageProperty { get; private set; }

        public ConfigureIvid()
        {
            ConfigureCredentials();
            ConfigureRequestMessageProperty();
        }

        private void ConfigureCredentials()
        {
            Client = new HpiServiceClient();

            if (Client == null || Client.ClientCredentials == null)
                throw new Exception("Cannot configure IVID Web Service");

            Client.ClientCredentials.UserName.UserName = IvidConfiguration.Username;
            Client.ClientCredentials.UserName.Password = IvidConfiguration.Password;
        }

        private void ConfigureRequestMessageProperty()
        {
            RequestMessageProperty =
                AuthenticationHeaders.CreateBasicHttpRequestMessageProperty(IvidConfiguration.Username,
                    IvidConfiguration.Password);
        }

        public void CloseWebService()
        {
            if (Client == null) return;

            Client.Close();
        }
    }
}
