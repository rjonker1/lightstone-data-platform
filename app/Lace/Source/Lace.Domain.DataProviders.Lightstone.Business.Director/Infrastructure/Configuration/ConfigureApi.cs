using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Common.Logging;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Business.Director.LightstoneBusinessServiceReference;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureApi
    {
        // email: murray@lightstone.co.za
        //pass: Pass!1234
        private readonly ILog _log = LogManager.GetLogger<ConfigureApi>();
        public readonly string Username = Credentials.LightstoneBusinessApiUsername();
        public readonly string Password = Credentials.LightstoneBusinessApiPassword();
        public readonly Guid UserToken;

        [DataMember]
        public apiSoapClient Client { get; private set; }

        public ConfigureApi()
        {
            Client = new apiSoapClient();
            if (Client.State == CommunicationState.Closed)
                Client.Open();

            _log.InfoFormat("Attempting to login to Lightstone Business APi using username {0} and password {1}", Username, Password);
            UserToken = Client.authenticateUser(Username, Password);
        }

        public void CloseSource()
        {
            if (Client == null) return;
            Client.Close();
        }
    }
}
