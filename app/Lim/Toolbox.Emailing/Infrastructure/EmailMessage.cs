using System.Runtime.Serialization;

namespace Toolbox.Emailing.Infrastructure
{
    [DataContract]
    public class EmailMessage
    {
        public EmailMessage(string ccAddress, string bccAddress, string address, string subject, string body,string fromAddress)
        {
            CcAddress = ccAddress;
            BccAddress = bccAddress;
            Address = address;
            Subject = subject;
            Body = body;
            FromAddress = fromAddress;
        }

        [DataMember] public readonly string FromAddress;
        [DataMember] public readonly string CcAddress;
        [DataMember] public readonly string BccAddress;
        [DataMember] public readonly string Address;
        [DataMember] public readonly string Subject;
        [DataMember] public readonly string Body;
    }
}
