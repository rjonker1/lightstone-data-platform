using Lace.Shared.Extensions;
using Lace.Toolbox.PCubed;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure
{
    public static class HandleRequest
    {
        public static ConsumerViewQuery GetQuery(IAmPCubedEzScoreRequest request)
        {
            return new ConsumerViewQuery(request.IdNumber.GetValue(), request.PhoneNumber.GetValue(), request.EmailAddress.GetValue());
        }
        
    }
}
