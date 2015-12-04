using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Entities.Requests
{
    public struct RequestBuilderContext
    {
        public RequestBuilderContext(ICollection<IAmRequestField> requests, IHaveUser user, string packageName, string contactNumber)
        {
            Requests = requests;
            User = user;
            PackageName = packageName;
            ContactNumber = contactNumber;
        }

        public readonly ICollection<IAmRequestField> Requests;
        public readonly IHaveUser User;
        public readonly string ContactNumber;
        public readonly string PackageName;
    }
}
