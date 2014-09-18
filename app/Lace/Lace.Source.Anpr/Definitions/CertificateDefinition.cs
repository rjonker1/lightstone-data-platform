using System.Xml.Serialization;

namespace Lace.Source.Anpr.Definitions
{
    public class CertificateDefinition : IDefineTheCertificate
    {
        public CertificateDefinition()
        {

        }

        public CertificateDefinition(string name, string displayName, bool isActive, bool isDefault, string description,
            IDefineTheProximity proximity, IDefineTheCredentials credentials, string endpoint)
        {
            Name = name;
            DisplayName = displayName;
            IsActive = isActive;
            IsDefault = isDefault;
            Description = description;
            Proximity = proximity;
            Credentials = credentials;
            Endpoint = endpoint;
        }

        [XmlIgnore]
        public bool HasCredentials
        {
            get
            {
                return Credentials != null;
            }
        }

        [XmlIgnore]
        public bool HasProximity
        {
            get
            {
                return Proximity != null;
            }
        }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsDefault { get; private set; }

        public string Description { get; private set; }

        public IDefineTheProximity Proximity { get; private set; }

        public IDefineTheCredentials Credentials { get; private set; }

        public string Endpoint { get; private set; }
    }
}
