using System;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Lightstone.Business.LightstoneBusinessServiceReference;


namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureLighstoneBusinessSource
    {


        //private readonly string Username = Credentials.LightstoneBusinessApiEmail();
        //private readonly string Password = Credentials.LightstoneBusinessApiPassword();

        //public readonly string UserToken;

        [DataMember]
        public LightstoneBusinessServiceReference.apiSoapClient Proxy { get; private set; }

        public ConfigureLighstoneBusinessSource()
        {
            Proxy = new apiSoapClient();


            // TODO: confirm if this should be called in the configuration or per request.
            // Should the proxy not be closed after every request?


            //UserToken = Proxy.authenticateUser(Username, Password).ToString();
        }

        public void CloseSource()
        {
            if (Proxy == null) return;
            Proxy.Close();
        }
    }
}
