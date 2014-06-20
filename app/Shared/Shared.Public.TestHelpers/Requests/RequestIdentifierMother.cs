﻿using DataPlatform.Shared.Identifiers;

namespace Shared.Public.TestHelpers.Requests
{
    public class RequestIdentifierMother
    {
        public static RequestIdentifier DefaultRequestIdentifier()
        {
            return new RequestIdentifierBuilder().With(new DefaultRequestIdentifier()).Build();
        }
    }
}