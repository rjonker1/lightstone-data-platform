
using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public interface IUser
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

        bool HasTransactions { get; set; }
    }

    public class User : IUser //: UserTransaction
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual bool HasTransactions { get; set; }

        public User() { }
    }
}