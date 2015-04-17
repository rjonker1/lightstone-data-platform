using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    public class UserMessage : Entity
    {
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public UserMessage() { }
    }
}