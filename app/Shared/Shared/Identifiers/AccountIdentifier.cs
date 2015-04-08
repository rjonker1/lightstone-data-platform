using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class AccountIdentifier
    {
        public AccountIdentifier()
        {
        }

        public AccountIdentifier(string accountNumber)
        {
            AccountNumber = accountNumber;
        }

        [DataMember]
        public string AccountNumber { get; private set; }
    }
}
