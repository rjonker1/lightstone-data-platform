using System;
using DataPlatform.Shared.Public.Helpers;
using DataPlatform.Shared.Public.Identifiers;

namespace Shared.Public.TestHelpers.Packages
{
    public class DefaultPackageIdentifier : IDefinePackageIdentifer
    {
        public Guid Id
        {
            get { return new Guid("996F715A-9C90-4D68-8948-92D89D6AD760"); }
        }

        public VersionIdentifier Version
        {
            get { return new VersionIdentifier(1, SystemTime.Now()); }
        }
    }
}