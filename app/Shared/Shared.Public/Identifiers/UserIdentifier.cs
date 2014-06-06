using System;

namespace DataPlatform.Shared.Public.Identifiers
{
    public class UserIdentifier
    {
        public UserIdentifier(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}