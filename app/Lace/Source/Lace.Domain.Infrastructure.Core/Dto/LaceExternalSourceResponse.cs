using Lace.Domain.Core.Contracts;
namespace Lace.Domain.Infrastructure.Core.Dto
{
    public class LaceExternalSourceResponse
    {
        public IProvideResponseFromLaceDataProviders Response { get; set; }
    }
}
