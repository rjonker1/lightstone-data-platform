using System;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Lightstone.Property.LightstonePropertyServiceReference;


namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureSource
    {
        [DataMember]
        public PropertiesSoapClient Client { get; private set; }

        public ConfigureSource()
        {
            Client = new PropertiesSoapClient();
        }

        public void CloseSource()
        {
            if (Client == null) return;
            Client.Close();
        }
    }
}
