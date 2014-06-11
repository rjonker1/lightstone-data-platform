using System;
using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Users
{
    public class UserIdentifierBuilder
    {
        private Guid id;

        public UserIdentifier Build()
        {
            return new UserIdentifier(id);
        }

        public UserIdentifierBuilder With(IDefineUserIdentifier data)
        {
            return WithId(data.Id);
        }

        public UserIdentifierBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }
    }
}