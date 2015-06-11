using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Common.Logging;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Business.Company.LightstoneBusinessServiceReference;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureSource
    {
        // email: murray@lightstone.co.za
        //pass: Pass!1234
        private readonly ILog _log = LogManager.GetLogger<ConfigureSource>();
        private readonly string _username = Credentials.LightstoneBusinessApiUsername();
        private readonly string _password = Credentials.LightstoneBusinessApiPassword();
        public readonly Guid UserToken;

        [DataMember]
        public apiSoapClient Client { get; private set; }

        public ConfigureSource()
        {
            Client = new apiSoapClient();
            if(Client.State == CommunicationState.Closed)
                Client.Open();

            _log.InfoFormat("Attempting to login to Lightstone Business APi using username {0} and password {1}", _username,_password);
            UserToken = Client.authenticateUser(_username, _password);
        }

        public void CloseSource()
        {
            if (Client == null) return;
            Client.Close();
        }
    }
}
