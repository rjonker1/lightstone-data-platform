﻿using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Users
{
    public class UserIdentifierMother
    {
        public static UserIdentifier DefaultUserIdentifier()
        {
            return new UserIdentifierBuilder().With(new DefaultUserIdentifier()).Build();
        }
    }
}