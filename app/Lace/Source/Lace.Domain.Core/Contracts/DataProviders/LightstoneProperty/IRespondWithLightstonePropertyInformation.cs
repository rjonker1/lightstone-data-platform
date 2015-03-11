using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.LightstoneProperty
{
    public interface IRespondWithLightstonePropertyInformation : IProvideType
    {
        IRespondWithPropertyRequestData RequestData { get; }
        IRespondWithProperty Properties { get;  }
    }
}
