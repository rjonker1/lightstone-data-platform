using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Director.LightstoneBusinessServiceReference;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public sealed class ConfigureApi
    {
        // email: murray@lightstone.co.za
        //pass: Pass!1234
        public readonly string Username = LightstoneBusinessConfiguration.Username;
        public readonly string Password = LightstoneBusinessConfiguration.Password;
        public readonly Guid UserToken;

        [DataMember]
        public apiSoapClient Client { get; private set; }

        public ConfigureApi()
        {
            Client = new apiSoapClient();
            if (Client.State == CommunicationState.Closed)
                Client.Open();
            UserToken = Client.authenticateUser(Username, Password);
        }

        public void CloseSource()
        {
            if (Client == null) return;
            Client.Close();
        }
    }
}
