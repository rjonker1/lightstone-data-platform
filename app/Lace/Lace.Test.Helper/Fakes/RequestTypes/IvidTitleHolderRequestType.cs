using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class IvidTitleHolderRequest: IAmIvidTitleholderRequest
    {
        private IvidTitleHolderRequest()
        {
            
        }

        public static IAmIvidTitleholderRequest WithVin(string vinNumber, string email, string requestorName)
        {
            return new IvidTitleHolderRequest()
            {
                VinNumber = VinNumberRequestField.Get(vinNumber),
                RequesterEmail = EmailField.Get(email),
                RequesterName = RequestorNameField.Get(requestorName)
            };
        }


        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}
