using Lace.Domain.Core.Requests.Contracts.RequestFields;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities.Requests
{
    public class AnprRequest : IAmAnprRequest
    {
        public IAmImageRequestField Image { get; private set; }

        public AnprRequest(IAmImageRequestField image)
        {
            Image = image;
        }
    }
}