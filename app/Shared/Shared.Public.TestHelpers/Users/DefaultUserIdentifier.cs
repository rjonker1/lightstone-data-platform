using System;

namespace Shared.Public.TestHelpers.Users
{
    public class DefaultUserIdentifier : IDefineUserIdentifier
    {
        public Guid Id
        {
            get { return new Guid("6F9E371B-C3DD-47EB-8A36-F092DA48EECE"); }
        }
    }
}