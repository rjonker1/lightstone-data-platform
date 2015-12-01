using System.Runtime.Serialization;

namespace Monitoring.Domain.Identifiers
{
    public class ActionIdentifier
    {
        [DataMember]
        public string Name { get; private set; }

        public ActionIdentifier(string name)
        {
            Name = name;
        }
    }
}
