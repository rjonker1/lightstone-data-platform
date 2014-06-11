using System;
using Shared.Public.TestHelpers.Systems;

namespace Shared.Public.TestHelpers.Requests
{
    public class DefaultRequestIdentifier : IDefineRequestIdentifier
    {
        public Guid Id
        {
            get { return new Guid("3826492A-9C90-AAAA-8948-92D89D6AD760"); }
        }

        public SystemIdentifierBuilder SystemIdentifier
        {
            get { return new SystemIdentifierBuilder().With(new DefaultTestSystem()); }
        }
    }
}