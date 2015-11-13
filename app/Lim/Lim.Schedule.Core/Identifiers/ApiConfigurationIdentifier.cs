using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiConfigurationIdentifier
    {
        public ApiConfigurationIdentifier(string baseAddress, string suffix, ApiAuthenticationIdentifier authentication,
            ActionIdentifier action, IntegrationTypeIdentifier type, FrequencyIdentifier frequency)
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
        public ActionIdentifier Action { get; private set; }

        [DataMember]
        public IntegrationTypeIdentifier Type { get; private set; }

        [DataMember]
        public FrequencyIdentifier Frequency { get; private set; }
    }
}