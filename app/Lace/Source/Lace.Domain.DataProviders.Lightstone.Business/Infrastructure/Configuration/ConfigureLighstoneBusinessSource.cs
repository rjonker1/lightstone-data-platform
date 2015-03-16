using System;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Lightstone.Business.LightstoneBusinessServiceReference;


namespace Lace.Domain.DataProviders.Lightstone.Business.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureLighstoneBusinessSource
    {
        [DataMember]
        public LightstoneBusinessServiceReference.apiSoapClient Proxy { get; private set; }

        public ConfigureLighstoneBusinessSource()
        {
            Proxy = new apiSoapClient();
        }

        public void CloseSource()
        {
            if (Proxy == null) return;
            Proxy.Close();
        }
    }
}
