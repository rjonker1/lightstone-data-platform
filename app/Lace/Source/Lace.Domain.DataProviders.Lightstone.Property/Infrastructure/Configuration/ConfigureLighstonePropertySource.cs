using System;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Lightstone.Property.LightstonePropertyServiceReference;


namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureLighstonePropertySource
    {
        [DataMember]
        public LightstonePropertyServiceReference.PropertiesSoapClient Proxy { get; private set; }

        public ConfigureLighstonePropertySource()
        {
            Proxy = new PropertiesSoapClient();
        }

        public void CloseSource()
        {
            if (Proxy == null) return;
            Proxy.Close();
        }
    }
}
