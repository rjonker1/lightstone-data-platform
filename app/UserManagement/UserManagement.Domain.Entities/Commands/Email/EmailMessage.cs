using System.Collections.Generic;

namespace UserManagement.Domain.Entities.Commands.Email
{
    public class EmailMessage
    {
        public IEnumerable<string> ToAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailMessage(IEnumerable<string> toAddresses, string subject, string body)
        {
            ToAddresses = toAddresses;
            Subject = subject;
            Body = body;
        }
    }
}