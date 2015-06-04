using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiConfigurationIdentifier
    {
        public ApiConfigurationIdentifier(string baseAddress, string suffix, ApiAuthenticationIdentifier authentication,
            IntegrationActionIdentifier action, IntegrationTypeIdentifier type, IntegrationFrequencyIdentifier frequency)
        {
            BaseAddress = baseAddress;
            Suffix = suffix;
            Authentication = authentication;
            Action = action;
            Type = type;
            Frequency = frequency;
        }

        [DataMember]
        public string BaseAddress { get; private set; }

        [DataMember]
        public string Suffix { get; private set; }

        [DataMember]
        public ApiAuthenticationIdentifier Authentication { get; private set; }

        [DataMember]
        public IntegrationActionIdentifier Action { get; private set; }

        [DataMember]
        public IntegrationTypeIdentifier Type { get; private set; }

        [DataMember]
        public IntegrationFrequencyIdentifier Frequency { get; private set; }
    }
}