using System;

namespace UserManagement.Domain.Entities.Commands.UserAliases
{
    public class LinkUserAliasCommand
    {
        public Guid AliasId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }

        public LinkUserAliasCommand(Guid aliasId, Guid customerId, Guid userId)
        {
            AliasId = aliasId;
            CustomerId = customerId;
            UserId = userId;
        }
    }
}