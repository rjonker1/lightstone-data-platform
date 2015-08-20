using System;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.LightsoneSpecificationsServiceReference;


namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Configuration
{
    [Serializable]
    [DataContract]
    public class ConfigureSource
    {
        [DataMember]
        public SQSServicesSoapClient Client { get; private set; }

        public ConfigureSource()
        {
            Client = new SQSServicesSoapClient();
        }

        public void CloseSource()
        {
            if (Client == null) return;
            Client.Close();
        }
    }
}
