using System;
using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiPullIntegration
    {
        public ApiPullIntegration(Guid key, ApiConfigurationIdentifier configuration, IntegrationClientIdentifier integrationClient)
        {
            Key = key;
            Configuration = configuration;
            IntegrationClient = integrationClient;
        }

        [DataMember]
        public Guid Key { get; private set; }


        [DataMember]
        public ApiConfigurationIdentifier Configuration { get; private set; }

        [DataMember]
        public IntegrationClientIdentifier IntegrationClient { get; private set; }
    }
}