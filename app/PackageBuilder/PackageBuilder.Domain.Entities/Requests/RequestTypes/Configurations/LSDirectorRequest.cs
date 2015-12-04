using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class LightstoneDirectorRequest : IAmLightstoneBusinessDirectorRequest
    {
        public LightstoneDirectorRequest(ICollection<IAmRequestField> requestFields)
        {
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            FirstName = requestFields.GetRequestField<IAmFirstNameRequestField>();
            Surname = requestFields.GetRequestField<IAmSurnameRequestField>();
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmFirstNameRequestField FirstName { get; private set; }
        public IAmSurnameRequestField Surname { get; private set; }
    }
}