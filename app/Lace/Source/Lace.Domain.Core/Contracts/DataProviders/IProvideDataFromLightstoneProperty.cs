using Lace.Domain.Core.Contracts.DataProviders.LightstoneProperty;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneProperty : IPointToLaceProvider
    {
        IRespondWithLightstonePropertyInformation LightstonePropertyInformation { get; }
        string Data { get; }
    }
}