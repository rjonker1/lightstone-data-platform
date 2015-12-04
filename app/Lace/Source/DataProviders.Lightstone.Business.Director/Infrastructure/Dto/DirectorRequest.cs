using System.Runtime.Serialization;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto
{
    [DataContract]
    public sealed class DirectorRequest
    {
        //const string idNumber = "7902065199085";
        private readonly IAmLightstoneBusinessDirectorRequest _request;

        public DirectorRequest()
        {
        }

        public DirectorRequest(IAmLightstoneBusinessDirectorRequest request)
        {
            _request = request;
        }

        public DirectorRequest Map()
        {
            IdNumber = _request.IdNumber.GetValue();
            FirstName = _request.FirstName.GetValue();
            Surname = _request.Surname.GetValue();
            return this;
        }

        public DirectorRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(IdNumber) || ValidIdNumber();
            return this;
        }

        private bool ValidIdNumber()
        {
            long id;
            long.TryParse(IdNumber, out id);
            return id > 0;
        }

        [DataMember]
        public bool IsValid { get; private set; }

        [DataMember]
        public string IdNumber { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string Surname { get; private set; }
    }
}